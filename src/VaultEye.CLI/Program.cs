using VaultEye.Core.services;
using VaultEye.Models;
using VaultEye.Reporting;
using VaultEye.Reporting.formatters;

namespace VaultEye.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartProgram();

            while (true)
            {
                string selectedScanning = SelectScanningMode();

                switch (selectedScanning)
                {
                    case "1":
                        ScanResult result = StartDirectoryScanner();
                        foreach (var finding in result.Findings)
                        {
                            ConsoleFindingFormatter.Print(finding);
                        }
                        ConsoleSummaryFormatter.Print(result);
                        CloseProgram();
                        return;
                    case "2":
                    case "3":
                        ShowNotImplemented();
                        break;
                    case "0":
                        CloseProgram();
                        return;
                    default:
                        ShowInvalidOption();
                        break;
                }
            }
        }

        #region PRIVATE METHODS

        private static void StartProgram()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
                ██╗   ██╗ █████╗ ██╗   ██╗██╗  ████████╗███████╗██╗   ██╗███████╗
                ██║   ██║██╔══██╗██║   ██║██║  ╚══██╔══╝██╔════╝╚██╗ ██╔╝██╔════╝
                ██║   ██║███████║██║   ██║██║     ██║   █████╗   ╚████╔╝ █████╗
                ╚██╗ ██╔╝██╔══██║██║   ██║██║     ██║   ██╔══╝    ╚██╔╝  ██╔══╝
                 ╚████╔╝ ██║  ██║╚██████╔╝███████╗██║   ███████╗   ██║   ███████╗
                  ╚═══╝  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝   ╚══════╝   ╚═╝   ╚══════╝
            ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" VaultEye Security Scanner");
            Console.WriteLine(" Lightweight AppSec & Secret Scanning Tool");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------\n");
            Console.ResetColor();
        }

        private static string SelectScanningMode()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[ Select a scanning mode ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  [1] File Scanning");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("  [2] Repository Scanning (Coming soon)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("  [3] Docker Scanning (Coming soon)");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  [0] Exit VaultEye");
            Console.ResetColor();
            
            Console.Write("\n>> ");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = input.Trim();

            if (input.Length > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[!] Input too long!\n");
                Console.ResetColor();

                return string.Empty;
            }

            return input;
        }

        private static ScanResult StartDirectoryScanner()
        {
            Console.Write("\nSet the directory to scan >> ");

            string? selectedDirectory = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(selectedDirectory))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[!] Invalid directory!");
                Console.ResetColor();

                return new ScanResult();
            }

            var core = new ScanOrchestrator();

            return core.InitCore(selectedDirectory);
        }

        private static void ShowNotImplemented()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[*] Method not implemented yet!\n");
            Console.ResetColor();
        }

        private static void ShowInvalidOption()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[!] Option not allowed!\n");
            Console.ResetColor();
        }

        private static void CloseProgram()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[%] VaultEye shutting down...");
            Console.ResetColor();

            Thread.Sleep(1200);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[#] Goodbye.\n");
            Console.ResetColor();
        }

        #endregion
    }
}