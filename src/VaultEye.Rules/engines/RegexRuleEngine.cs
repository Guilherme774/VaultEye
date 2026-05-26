using System.Text.RegularExpressions;
using VaultEye.Models;

namespace VaultEye.Rules.engines
{
    public class RegexRuleEngine
    {
        public List<Finding> Analyze(IEnumerable<ScannedFile> scannedFiles, IEnumerable<Rule> rules)
        {
            var findings = new List<Finding>();

            foreach (var scannedFile in scannedFiles)
            {
                int lineNumber = 0;

                foreach (var line in scannedFile.Content)
                {
                    lineNumber++;

                    foreach (var rule in rules)
                    {
                        if (Regex.IsMatch(line, rule.Pattern, RegexOptions.IgnoreCase))
                        {
                            findings.Add(new Finding
                            {
                                RuleName = rule.Name,
                                Category = rule.Category,
                                Severity = rule.Severity,
                                FilePath = scannedFile.FileName,
                                LineNumber = lineNumber,
                                MatchedContent = line.Trim()
                            });
                        }
                    }
                }
            }

            return findings;
        }
    }
}