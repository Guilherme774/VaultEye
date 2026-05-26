using VaultEye.Models;

namespace VaultEye.Rules.rules
{
    public static class ConnectionStringRule
    {
        public static Rule Create()
        {
            return new Rule
            {
                Name = "Connection String",
                Severity = "HIGH",
                Pattern = @"(Server|Data Source|Host)=.+;(Database|Initial Catalog)=.+;(User Id|UID|Username)=.+;(Password|PWD)=.+;"
            };
        }
    }
}