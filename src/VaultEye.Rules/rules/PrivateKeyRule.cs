using VaultEye.Models;

namespace VaultEye.Rules.rules
{
    public static class PrivateKeyRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "Private Key",
                Severity = "CRITICAL",
                Pattern = @"-----BEGIN (RSA|DSA|EC|OPENSSH|PGP)? ?PRIVATE KEY-----"
            };
        }        
    }
}