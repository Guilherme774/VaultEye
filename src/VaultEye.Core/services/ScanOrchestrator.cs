using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaultEye.Scanner.services;
using VaultEye.Rules.engines;
using VaultEye.Rules.rules;
using VaultEye.Models;

namespace VaultEye.Core.services
{
    public class ScanOrchestrator
    {
        public void InitCore(string directory)
        {
            var scanner = new FileScannerService();
            var lines = scanner.ReadFile(directory);
            var engine = new RegexRuleEngine();
            var findings = engine.Analyze(directory, lines, new List<Rule>
            {
                PasswordRule.Create()
            });

            foreach(var finding in findings)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[{finding.Severity}] {finding.RuleName}");
                Console.ResetColor();
                Console.WriteLine($"File: {finding.FilePath}");
                Console.WriteLine($"Line: {finding.LineNumber}");
                Console.WriteLine($"Match: {finding.MatchedContent}");
            }
        }
    }
}