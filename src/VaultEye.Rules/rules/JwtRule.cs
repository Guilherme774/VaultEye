using VaultEye.Models;
using VaultEye.Models.enums;

namespace VaultEye.Rules.rules
{
    public static class JwtRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "JWT Token",
                Severity = SeverityType.HIGH,
                Category = CategoryType.Authentication,
                Pattern = @"eyJ[a-zA-Z0-9_-]+\.[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+"
            };
        }
    }
}