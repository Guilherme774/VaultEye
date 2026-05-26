using VaultEye.Models;
using VaultEye.Models.enums;

namespace VaultEye.Rules.rules
{
    public static class AwsKeyRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "AWS Key",
                Severity = SeverityType.CRITICAL,
                Category = CategoryType.Cloud,
                Pattern = @"AKIA[0-9A-Z]{16}"
            };
        }
    }
}