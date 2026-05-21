using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaultEye.Core.services;

namespace VaultEye.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[@] Welcome to VaultEye Scanner");

            var core = new ScanOrchestrator();

            core.InitCore();

            Console.WriteLine("[@] VaultEye turning off, see ya!");
        }
    }
}