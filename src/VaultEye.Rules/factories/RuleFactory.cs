using VaultEye.Models;
using VaultEye.Rules.rules;

public static class RuleFactory
{
    public static List<Rule> GetRules()
    {
        return
        [
            PasswordRule.Create(),
            JwtRule.Create(),
            AwsKeyRule.Create(),
            GithubTokenRule.Create(),
            PrivateKeyRule.Create(),
            ConnectionStringRule.Create(),
            ApiKeyRule.Create(),
            BearerTokenRule.Create()
        ];
    }
}