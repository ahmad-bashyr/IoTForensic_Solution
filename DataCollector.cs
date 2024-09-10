using System.IO;
using System.Threading.Tasks;

namespace IoTForensicSolution.IoTDataCollector
{
    public class DataCollector
    {
        private const string FilePath = @"C:\Users\bashir\Documents\encrypted_data.json";  // Updated file path

        public static async Task<string> CollectDataAsync()
        {
            // Simulate data collection by reading the encrypted data from the file
            if (File.Exists(FilePath))
            {
                return await File.ReadAllTextAsync(FilePath);
            }
            else
            {
                throw new FileNotFoundException($"The file {FilePath} was not found.");
            }
        }
    }
}
