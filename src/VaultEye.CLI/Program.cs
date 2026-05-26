using VaultEye.Core.services;

namespace VaultEye.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            startProgram();

            while(true)
            {
                string selectedScanning = selectScanningMode();

                switch(selectedScanning)
                {
                    case "1":
                        int findings = startDirectoryScanner();
                        closeProgram(findings);
                        return;
                    case "2":
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n[*] Method not implemented yet!\n");
                        Console.ResetColor();
                        break;
                    case "0":
                        closeProgram(0);
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n[!] Option not allowed!\n");
                        Console.ResetColor();
                        break;
                }
            }
        }

        #region PRIVATE METHODS

        private static void startProgram()
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

        private static string selectScanningMode()
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

            Console.Write("\n\n>> ");
            string? input = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = input.Trim();

            if(input.Length > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[!] Input too long!");
                Console.ResetColor();

                return string.Empty;
            }

            return input;
        }

        private static int startDirectoryScanner()
        {
            var core = new ScanOrchestrator();
            Console.Write("\n\nSet the directory to scan >> ");
            string? selectedDirectory = Console.ReadLine();
            int findings = core.InitCore(selectedDirectory!);

            return findings;
        }

        private static void closeProgram(int findings)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  Scan completed successfully!");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  Findings detected: {findings}");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[%] VaultEye shutting down. . .");
            Console.ResetColor();

            Thread.Sleep(1200);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[#] Goodbye.\n");
            Console.ResetColor();
        }

        #endregion
    }
}