using System;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure
{
    public class LoginProvider
    {
        private readonly string _userNamePattern;
        private readonly string _defaultPassword;
        private Guid _securityGuid;

        public LoginProvider(ConfigurationProvider configurationProvider)
        {
            _defaultPassword = configurationProvider.GetDefaultPassword();
            _securityGuid = new Guid(configurationProvider.GetSecurityGuid());
            _userNamePattern = configurationProvider.GetUserNamePattern();
        }

        private string GetUserName(string roleName)
        {
            var userName =
                _userNamePattern.Replace("{guid}", _securityGuid.ToString()).Replace("{roleName}", roleName).Trim();
            return userName;
        }

        public LoginData GetAdmin()
        {
            const string roleName = "Administrator";
            var userName = GetUserName(roleName);
            var loginData = new LoginData(userName, _defaultPassword);
            return loginData;
        }

        public LoginData GetProducer()
        {
            const string roleName = "Producer";
            var userName = GetUserName(roleName);
            var loginData = new LoginData(userName, _defaultPassword);
            return loginData;
        }

        public LoginData GetClient()
        {
            const string roleName = "Client";
            var userName = GetUserName(roleName);
            var loginData = new LoginData(userName, _defaultPassword);
            return loginData;
        }

        public LoginData GetDistributor()
        {
            const string roleName = "Distributor";
            var userName = GetUserName(roleName);
            var loginData = new LoginData(userName, _defaultPassword);
            return loginData;
        }

        public LoginData GetTalent()
        {
            const string roleName = "Talent";
            var userName = GetUserName(roleName);
            var loginData = new LoginData(userName, _defaultPassword);
            return loginData;
        }
    }
}
