namespace VaultEye.Models
{
    public class Finding
    {
        public string RuleName { get; set; }
            = string.Empty;

        public string Severity { get; set; }
            = string.Empty;

        public string FilePath { get; set; }
            = string.Empty;

        public int LineNumber { get; set; }

        public string MatchedContent { get; set; }
            = string.Empty;
    }
}