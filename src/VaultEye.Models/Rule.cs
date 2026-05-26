using VaultEye.Models.enums;

namespace VaultEye.Models
{
    public class Rule
    {
        public string Name { get; set; }
            = string.Empty;

        public string Pattern { get; set; }
            = string.Empty;

        public SeverityType Severity { get; set; }

        public CategoryType Category { get; set; }
    }
}