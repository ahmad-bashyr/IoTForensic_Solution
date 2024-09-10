using System;
using System.IO;
using System.Security.Cryptography;

namespace IoTForensicSolution.IoTEncryptionHandler
{
    public class EncryptionHandler
    {
        private readonly byte[] _key;

        public EncryptionHandler(string key)
        {
            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            {
                throw new ArgumentException("Key must be 16, 24, or 32 bytes long");
            }

            _key = System.Text.Encoding.UTF8.GetBytes(key);
        }

        public string DecryptData(byte[] ciphertext, byte[] iv)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = _key;
                    aesAlg.IV = iv;
                    aesAlg.Mode = CipherMode.CFB;  // Ensure the mode matches the encryption mode
                    aesAlg.Padding = PaddingMode.None; // No padding for CFB mode

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (var msDecrypt = new MemoryStream(ciphertext))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Decryption Error: {ex.Message}");
                throw;
            }
        }
    }
}
 