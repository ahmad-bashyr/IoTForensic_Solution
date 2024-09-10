using System;
using System.IO;

namespace IoTForensicSolution.Utilities
{
    public static class Logger
    {
        private static readonly string logFilePath = "application.log";

        public static void Log(string message, string level = "INFO")
        {
            string logMessage = $"[{DateTime.UtcNow}] [{level}] {message}";
            Console.WriteLine(logMessage);
            LogToFile(logMessage);
        }

        private static void LogToFile(string message)
        {
            try
            {
                using var writer = new StreamWriter(logFilePath, append: true);
                writer.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.UtcNow}] [ERROR] Failed to write to log file: {ex.Message}");
            }
        }
    }
}
