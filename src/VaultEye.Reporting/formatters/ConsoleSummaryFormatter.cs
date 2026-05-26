using VaultEye.Models;

namespace VaultEye.Reporting
{
    public static class ConsoleSummaryFormatter
    {
        public static void Print(ScanResult result)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("══════════════════════════════════════");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("              Scan Summary");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("══════════════════════════════════════");
            Console.ResetColor();

            Console.WriteLine();
            PrintField("Files Scanned", result.FilesScanned.ToString());
            PrintField("Findings", result.FindingsCount.ToString());
            Console.WriteLine();

            PrintSeverity("CRITICAL", result.CriticalCount, ConsoleColor.Magenta);
            PrintSeverity("HIGH", result.HighCount, ConsoleColor.Red);
            PrintSeverity("MEDIUM", result.MediumCount, ConsoleColor.Yellow);
            PrintSeverity("LOW", result.LowCount, ConsoleColor.Green);
            Console.WriteLine();
            PrintField("Duration", $"{result.DurationSeconds:F2}s");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("══════════════════════════════════════");
            Console.ResetColor();
        }

        private static void PrintField(string label, string value)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {label.PadRight(15)}");
            Console.ResetColor();

            Console.WriteLine($": {value}");
        }

        private static void PrintSeverity(string severity, int count, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($" {severity.PadRight(15)}");
            Console.ResetColor();

            Console.WriteLine($": {count}");
        }
    }
}