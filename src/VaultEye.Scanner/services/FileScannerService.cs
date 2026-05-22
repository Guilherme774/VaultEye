using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaultEye.Scanner.services
{
    public class FileScannerService
    {
        public IEnumerable<string> ReadFile(string filePath)
        {   
            Console.WriteLine("[#] Scan started . . .");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[!] File not found: {filePath}");
                return Enumerable.Empty<string>();
            }

            var lines = File.ReadLines(filePath).ToList();
            return lines;
        }
    }
}