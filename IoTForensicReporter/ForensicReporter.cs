using System.Text;
using IoTForensicSolution.IoTAnalyzer;

namespace IoTForensicSolution.IoTForensicReporter
{
    public class ForensicReporter
    {
        public static string GenerateReport(AnalysisResult analysisResult)
        {
            var reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("---- Forensic Analysis Report ----");
            reportBuilder.AppendLine($"Date: {DateTime.UtcNow}");
            reportBuilder.AppendLine();
            reportBuilder.AppendLine("Analysis Data:");
            reportBuilder.AppendLine(analysisResult.AnalysisData);
            reportBuilder.AppendLine("----------------------------------");
            return reportBuilder.ToString();
        }
    }
}
