namespace VaultEye.Models
{
    public class Rule
    {
        public string Name { get; set; }
            = string.Empty;

        public string Pattern { get; set; }
            = string.Empty;

        public string Severity { get; set; }
            = string.Empty;
    }
}