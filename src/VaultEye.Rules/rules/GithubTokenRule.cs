using VaultEye.Models;

namespace VaultEye.Rules.rules
{
    public static class GithubTokenRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "GitHub Token",
                Severity = "CRITICAL",
                Pattern = @"gh[pousr]_[A-Za-z0-9_]{20,}"
            };
        }
    }
}