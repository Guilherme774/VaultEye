using VaultEye.Scanner.services;
using VaultEye.Rules.engines;
using VaultEye.Rules.rules;
using VaultEye.Models;

namespace VaultEye.Core.services
{
    public class ScanOrchestrator
    {
        public int InitCore(string directory)
        {
            var rules = RuleFactory.GetRules();
            var scanner = new FileScannerService();
            var scannedFiles = scanner.ReadFiles(directory);
            var engine = new RegexRuleEngine();
            var findings = engine.Analyze(scannedFiles, rules);

            foreach(var finding in findings)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[{finding.Severity}] {finding.RuleName}");
                Console.ResetColor();
                Console.WriteLine($"Category: {finding.Category}");
                Console.WriteLine($"File: {finding.FilePath}");
                Console.WriteLine($"Line: {finding.LineNumber}");
                Console.WriteLine($"Match: {finding.MatchedContent}");
            }

            return findings.Count;
        }
    }
}