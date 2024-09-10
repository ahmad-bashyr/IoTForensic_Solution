using System;
using System.Threading.Tasks;
using IoTForensicSolution.IoTDataCollector;
using IoTForensicSolution.IoTEncryptionHandler;
using IoTForensicSolution.IoTDataStorage;
using Newtonsoft.Json.Linq;

namespace IoTForensicSolution
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Starting IoT Forensic Solution");

            // Initialize the encryption handler and data storage services
            var encryptionHandler = new EncryptionHandler("16ByteSecretKey!");
            var dataContext = new DataContext();
            var dataStorage = new DataStorage(dataContext);

            while (true)
            {
                try
                {
                    // Collect the encrypted data from the file
                    string encryptedData = await DataCollector.CollectDataAsync();
                    Console.WriteLine($"Collected Encrypted Data: {encryptedData}");

                    // Parse the JSON data to extract the IV and ciphertext
                    var encryptedJson = JObject.Parse(encryptedData);
                    string ivString = encryptedJson["iv"]?.ToString();
                    string ciphertextString = encryptedJson["ciphertext"]?.ToString();

                    if (!string.IsNullOrEmpty(ivString) && !string.IsNullOrEmpty(ciphertextString))
                    {
                        // Convert Base64 strings back to byte arrays
                        byte[] iv = Convert.FromBase64String(ivString);
                        byte[] ciphertext = Convert.FromBase64String(ciphertextString);

                        // Decrypt the data
                        string decryptedData = encryptionHandler.DecryptData(ciphertext, iv);
                        Console.WriteLine($"Decrypted Data: {decryptedData}");

                        // Extract the temperature from the decrypted JSON
                        var jsonData = JObject.Parse(decryptedData);
                        double temperature = jsonData["temperature"]?.Value<double>() ?? double.NaN;
                        Console.WriteLine($"Extracted Temperature: {temperature} °C");

                        // Save decrypted data to the PostgreSQL database
                        await dataStorage.SaveDataAsync(decryptedData);
                        Console.WriteLine("Data saved to database.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to parse IV or Ciphertext from the JSON message.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                // Wait for a few seconds before checking for new data
                await Task.Delay(5000); // Adjust the delay as needed

                // Check if a key has been pressed to exit
                if (Console.KeyAvailable)
                {
                    Console.WriteLine("Exiting IoT Forensic Solution...");
                    break;
                }
            }
        }
    }
}
