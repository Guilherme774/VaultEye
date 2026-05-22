using System.Text.RegularExpressions;
using VaultEye.Models;

namespace VaultEye.Rules.engines
{
    public class RegexRuleEngine
    {
        public List<Finding> Analyze(
            string filePath,
            IEnumerable<string> lines,
            IEnumerable<Rule> rules)
        {
            var findings = new List<Finding>();

            int lineNumber = 0;

            foreach (var line in lines)
            {
                lineNumber++;

                foreach (var rule in rules)
                {
                    if (Regex.IsMatch(
                        line,
                        rule.Pattern,
                        RegexOptions.IgnoreCase))
                    {
                        findings.Add(new Finding
                        {
                            RuleName = rule.Name,
                            Severity = rule.Severity,
                            FilePath = filePath,
                            LineNumber = lineNumber,
                            MatchedContent = line.Trim()
                        });
                    }
                }
            }

            return findings;
        }
    }
}