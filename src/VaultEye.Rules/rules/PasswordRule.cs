using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using VaultEye.Models;

namespace VaultEye.Rules.rules
{
    public class PasswordRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "Hardcoded Password",
                Severity = "HIGH",
                Pattern = @"(password|pwd|passwd|secret|token|api[_-]?key)\w*\s*=\s*.+"
            };
        }
    }
}