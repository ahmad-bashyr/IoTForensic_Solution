namespace IoTForensicSolution.IoTDataCollector
{
    public interface IDeviceInterface
    {
        Task<string> CollectDataAsync();
    }
}
