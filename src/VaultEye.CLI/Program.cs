using VaultEye.Core.services;

namespace VaultEye.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write(@" 
                             /$$    /$$                    /$$   /$$     /$$$$$$$$                    
                            | $$   | $$                   | $$  | $$    | $$_____/                    
                            | $$   | $$ /$$$$$$  /$$   /$$| $$ /$$$$$$  | $$       /$$   /$$  /$$$$$$ 
                            |  $$ / $$/|____  $$| $$  | $$| $$|_  $$_/  | $$$$$   | $$  | $$ /$$__  $$
                             \  $$ $$/  /$$$$$$$| $$  | $$| $$  | $$    | $$__/   | $$  | $$| $$$$$$$$
                              \  $$$/  /$$__  $$| $$  | $$| $$  | $$ /$$| $$      | $$  | $$| $$_____/
                               \  $/  |  $$$$$$$|  $$$$$$/| $$  |  $$$$/| $$$$$$$$|  $$$$$$$|  $$$$$$$
                                \_/    \_______/ \______/ |__/   \___/  |________/ \____  $$ \_______/
                                                                                   /$$  | $$          
                                                                                  |  $$$$$$/          
                                                                                   \______/           ");


            Console.WriteLine("\n[@] Welcome to VaultEye Scanner");
            Console.WriteLine("[@] Select the type of scanner do you want:\n");
            Console.WriteLine("(1) File Scanning");
            Console.WriteLine("(2) Repository Scanning");
            Console.WriteLine("(0) Exit VaultEye");

            Console.Write("\n\n\n\n>> ");
            string selectedScanning = Console.ReadLine();

            switch(selectedScanning)
            {
                case "1":
                    var core = new ScanOrchestrator();

                    Console.Write("\n\nSet the directory to scan >> ");
                    string selectedDirectory = Console.ReadLine();
                    core.InitCore(selectedDirectory);
                    Console.WriteLine("[@] VaultEye turning off, see ya!");
                    break;
                case "2":
                    Console.WriteLine("[*] Method not implemented yet!");
                    break;
                default:
                    Console.WriteLine("[@] VaultEye turning off, see ya!");
                    break;
            }
        }
    }
}