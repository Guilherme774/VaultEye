using VaultEye.Models;
using VaultEye.Models.enums;

namespace VaultEye.Rules.rules
{
    public static class GithubTokenRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "GitHub Token",
                Severity = SeverityType.CRITICAL,
                Category = CategoryType.Tokens,
                Pattern = @"gh[pousr]_[A-Za-z0-9_]{20,}"
            };
        }
    }
}