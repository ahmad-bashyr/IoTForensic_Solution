namespace IoTForensicSolution.IoTAnalyzer
{
    public static class DataAnalyzer
    {
        public static AnalysisResult AnalyzeData(string data)
        {
            // Analyze the data and return the result
            return new AnalysisResult { AnalysisData = "Analyzed " + data };
        }
    }
}
