using VaultEye.Models;
using VaultEye.Models.enums;

namespace VaultEye.Rules.rules
{
    public class PasswordRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "Hardcoded Password",
                Severity = SeverityType.HIGH,
                Category = CategoryType.Credentials,
                Pattern = @"(password|pwd|passwd|secret|token|api[_-]?key)\w*\s*=\s*.+"
            };
        }
    }
}