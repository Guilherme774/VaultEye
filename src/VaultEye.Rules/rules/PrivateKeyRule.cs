using VaultEye.Models;
using VaultEye.Models.enums;

namespace VaultEye.Rules.rules
{
    public static class PrivateKeyRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "Private Key",
                Severity = SeverityType.CRITICAL,
                Category = CategoryType.Credentials,
                Pattern = @"-----BEGIN (RSA|DSA|EC|OPENSSH|PGP)? ?PRIVATE KEY-----"
            };
        }        
    }
}