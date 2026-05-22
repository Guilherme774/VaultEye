using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaultEye.Models
{
    public class Finding
    {
        public string RuleName { get; set; }
        public string Severity { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
        public string MatchedContent { get; set; }
    }
}