using VaultEye.Models;

namespace VaultEye.Rules.rules
{
    public static class ApiKeyRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "API Key",
                Severity = "HIGH",
                Pattern = @"(?i)(api[_-]?key|apikey)\s*[:=]\s*['""]?[A-Za-z0-9_\-]{16,}"
            };
        }
    }
}