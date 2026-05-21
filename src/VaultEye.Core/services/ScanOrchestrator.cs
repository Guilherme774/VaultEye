using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaultEye.Core.services
{
    public class ScanOrchestrator
    {
        public void InitCore()
        {
            Console.WriteLine("[#] Core initialized");

            Scan();

            Console.WriteLine("[#] Core services finalized");
        }

        private void Scan()
        {
            Console.WriteLine("[#] Scan started");
        }
    }
}