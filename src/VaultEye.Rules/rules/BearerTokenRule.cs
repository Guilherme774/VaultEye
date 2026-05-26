using VaultEye.Models;
using VaultEye.Models.enums;

namespace VaultEye.Rules.rules
{
    public static class BearerTokenRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "Bearer Token",
                Severity = SeverityType.HIGH,
                Category = CategoryType.Tokens,
                Pattern = @"Bearer\s+[A-Za-z0-9\-._~+/]+=*"
            };
        }
    }
}