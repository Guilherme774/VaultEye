using VaultEye.Models;
using VaultEye.Models.enums;

namespace VaultEye.Rules.rules
{
    public static class ConnectionStringRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "Connection String",
                Severity = SeverityType.HIGH,
                Category = CategoryType.Database,
                Pattern = @"(Server|Data Source|Host)=.+;(Database|Initial Catalog)=.+;(User Id|UID|Username)=.+;(Password|PWD)=.+;"
            };
        }
    }
}