using VaultEye.Models;

namespace VaultEye.Rules.rules
{
    public static class BearerTokenRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "Bearer Token",
                Severity = "HIGH",
                Pattern = @"Bearer\s+[A-Za-z0-9\-._~+/]+=*"
            };
        }
    }
}