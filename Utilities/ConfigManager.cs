using System.IO;
using Newtonsoft.Json;

namespace IoTForensicSolution.Utilities
{
    public class ConfigManager
    {
        public string EncryptionKey { get; set; } = "DefaultEncryptionKey123"; // Default value

        public static ConfigManager? LoadConfig(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // If the config file doesn't exist, create a default one
                var defaultConfig = new ConfigManager();
                File.WriteAllText(filePath, JsonConvert.SerializeObject(defaultConfig, Formatting.Indented));
                return defaultConfig;
            }

            var configContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<ConfigManager>(configContent);
        }
    }
}
