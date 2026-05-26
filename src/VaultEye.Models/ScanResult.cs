using VaultEye.Models.enums;

namespace VaultEye.Models
{
    public class ScanResult
    {
        public int FilesScanned { get; set; }

        public int FindingsCount { get; set; }

        public double DurationSeconds { get; set; }

        public List<Finding> Findings { get; set; }
            = new();

        public int CriticalCount =>
            Findings.Count(f => f.Severity == SeverityType.CRITICAL);

        public int HighCount =>
            Findings.Count(f => f.Severity == SeverityType.HIGH);

        public int MediumCount =>
            Findings.Count(f => f.Severity == SeverityType.MEDIUM);

        public int LowCount =>
            Findings.Count(f => f.Severity == SeverityType.LOW);
    }
}