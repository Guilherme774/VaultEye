using System.Text.Json;
using VaultEye.Models;

namespace VaultEye.Reporting.exporters
{
    public static class JsonReportExporter
    {
        public static void Export(ScanResult result, string outputPath = "report.json")
        {
            var options =
                new JsonSerializerOptions
                {
                    WriteIndented = true
                };

            string json = JsonSerializer.Serialize(result, options);

            File.WriteAllText(outputPath, json);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[+] JSON report exported: {outputPath}");
            Console.ResetColor();
        }
    }
}