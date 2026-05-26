using VaultEye.Scanner.services;
using VaultEye.Rules.engines;
using VaultEye.Rules.rules;
using VaultEye.Models;
using VaultEye.Reporting.formatters;
using System.Diagnostics;

namespace VaultEye.Core.services
{
    public class ScanOrchestrator
    {
        public ScanResult InitCore(string directory)
        {
            var stopwatch = Stopwatch.StartNew();
            var rules = RuleFactory.GetRules();
            var scanner = new FileScannerService();
            var scannedFiles = scanner.ReadFiles(directory).ToList();
            var engine = new RegexRuleEngine();
            List<Finding> findings = new();

            foreach (var scannedFile in scannedFiles)
            {
                findings.AddRange(engine.Analyze(scannedFile, rules));
            }

            stopwatch.Stop();

            return new ScanResult
            {
                FilesScanned = scannedFiles.Count,
                FindingsCount = findings.Count,
                Findings = findings,
                DurationSeconds = stopwatch.Elapsed.TotalSeconds
            };
        }
    }
}