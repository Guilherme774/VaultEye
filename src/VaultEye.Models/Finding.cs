using VaultEye.Models.enums;

namespace VaultEye.Models
{
    public class Finding
    {
        public string RuleName { get; set; }
            = string.Empty;

        public CategoryType Category { get; set; }

        public SeverityType Severity { get; set; }

        public string FilePath { get; set; }
            = string.Empty;

        public int LineNumber { get; set; }

        public string MatchedContent { get; set; }
            = string.Empty;
    }
}