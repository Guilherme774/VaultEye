namespace VaultEye.Models
{
    public class ScanResult
    {
        public List<Finding> Findings { get; set; }
            = new();
    }
}