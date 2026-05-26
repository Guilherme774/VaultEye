using VaultEye.Models;
using VaultEye.Models.enums;

namespace VaultEye.Reporting.formatters
{
    public static class ConsoleFindingFormatter
    {
        public static void Print(Finding finding)
        {
            string severity = finding.Severity.ToString();

            ConsoleColor severityColor = GetSeverityColor(finding.Severity);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n┌─────────────────────────────────────────────");
            Console.ResetColor();

            Console.Write("│ ");
            Console.ForegroundColor = severityColor;
            Console.Write($"[{severity}] ");
            Console.ResetColor();

            Console.WriteLine(finding.RuleName);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("├─────────────────────────────────────────────");
            Console.ResetColor();

            PrintField("Category", finding.Category.ToString());
            PrintField("File", finding.FilePath);
            PrintField("Line", finding.LineNumber.ToString());
            PrintField("Match", Truncate(finding.MatchedContent));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("└─────────────────────────────────────────────");
            Console.ResetColor();
        }

        private static void PrintField(string label, string value)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("│ ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{label.PadRight(9)} : ");
            Console.ResetColor();

            Console.WriteLine(value);
        }

        private static ConsoleColor GetSeverityColor(
            SeverityType severity)
        {
            return severity switch
            {
                SeverityType.LOW => ConsoleColor.Green,
                SeverityType.MEDIUM => ConsoleColor.Yellow,
                SeverityType.HIGH => ConsoleColor.Red,
                SeverityType.CRITICAL => ConsoleColor.Magenta,
                _ => ConsoleColor.White
            };
        }

        private static string Truncate(string value, int maxLength = 70)
        {
            if (value.Length <= maxLength)
                return value;

            return value[..maxLength] + "...";
        }
    }
}