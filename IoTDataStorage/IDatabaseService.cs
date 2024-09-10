namespace IoTForensicSolution.IoTDataStorage
{
    public interface IDatabaseService
    {
        Task SaveDataAsync(string data);
        Task<string> RetrieveDataAsync(string id); // Example for retrieving data by ID
    }
}
