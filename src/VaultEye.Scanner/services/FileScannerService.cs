using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaultEye.Models;

namespace VaultEye.Scanner.services
{
    public class FileScannerService
    {
        public IEnumerable<ScannedFile> ReadFile(string directory)
        {   
            Console.WriteLine("[#] Scan started . . .");

            string[] files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            List<ScannedFile> lines = new();

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    ScannedFile scanFile = new ScannedFile();
                    scanFile.FileName = file;
                    scanFile.Content = File.ReadLines(file).ToList();

                    lines.Add(scanFile);
                }
            }

            return lines;
        }
    }
}