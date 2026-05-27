using VaultEye.Core.services;
using VaultEye.Models;
using VaultEye.Reporting;
using VaultEye.Reporting.formatters;
using VaultEye.Reporting.exporters;

namespace VaultEye.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartProgram();

            if(args.Length > 0)
            {
                RunCliMode(args);
                return;
            }

            RunInteractiveMode();
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
            Console.WriteLine(" VaultEye Security Scanner v0.1-alpha");
            Console.WriteLine(" Lightweight AppSec & Secret Scanning Tool");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------\n");
            Console.ResetColor();
        }

        private static void RunInteractiveMode()
        {
            while(true)
            {
                string selectedScanning =
                    SelectScanningMode();

                switch(selectedScanning)
                {
                    case "1":
                        ScanResult result = StartDirectoryScanner();
                        PrintResults(result);
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

        private static void RunCliMode(string[] args)
        {
            if(args.Length < 2)
            {
                ShowCliHelp();
                return;
            }

            string command = args[0].ToLower();

            switch(command)
            {
                case "scan":
                    RunScanCommand(args);
                    break;
                case "help":
                case "h":
                    ShowCliHelp();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[!] Invalid CLI command!");
                    Console.ResetColor();

                    break;
            }
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

        private static void RunScanCommand(string[] args)
        {
            if(args.Length < 2)
            {
                ShowCliHelp();
                return;
            }

            string directory = args[1];
            bool exportJson = args.Contains("--json");
            var orchestrator = new ScanOrchestrator();

            ScanResult result = orchestrator.InitCore(directory);

            PrintResults(result);

            if(exportJson)
            {
                JsonReportExporter.Export(result);
            }

            CloseProgram();
        }

        private static void PrintResults(ScanResult result)
        {
            foreach(var finding in result.Findings)
            {
                ConsoleFindingFormatter.Print(finding);
            }

            ConsoleSummaryFormatter.Print(result);
        }

        private static void ShowCliHelp()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" VaultEye CLI Usage");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine(" scan   <directory>           Scan a directory");
            Console.WriteLine(" git    <url>  (Coming soon)  Scan a Github repository");
            Console.WriteLine(" docker <path> (Coming soon)  Scan a Docker environment");
            Console.WriteLine("\n --json                       Flag to export scan results to a JSON file");
            Console.WriteLine("\n help | h                     Show help");
            Console.WriteLine();
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