using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure
{
    public class ConfigurationProvider
    {
        public string GetBrowserName()
        {
            var browserName = GetConfiguration("Browser");
            return browserName;
        }

        public string GetSecurityGuid()
        {
            var browserName = GetConfiguration("Guid");
            return browserName;
        }

        public string GetUserNamePattern()
        {
            var browserName = GetConfiguration("UserNamePattern");
            return browserName;
        }

        public string GetTenantOverrideUrl()
        {
            try
            {
                var tenantOverride = GetConfiguration("OverrideToSingleTenantUrl");
                tenantOverride = tenantOverride == String.Empty ? null : tenantOverride;
                return tenantOverride;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GetBaseFilePath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            return path;
        }


        public string GetDefaultPassword()
        {
            var browserName = GetConfiguration("Password");
            return browserName;
        }

        public string GetTestCampaignFileName()
        {
            var browserName = GetConfiguration("JsonCampaign");
            return browserName;
        }

        public static string[] GetTenantNames()
        {
            var section = GetSection("tenants");
            var tenants = section.AllKeys.ToArray();
            return tenants;
        }

        public string GetTenantUrl(string name)
        {
            var section = GetSection("tenants");
            if (string.IsNullOrWhiteSpace(section[name]))
            {
                return string.Empty;
            }
            var url = section[name];
            return url;
        }

        public string GetVersionMajor()
        {
            var result = ConfigurationManager.AppSettings["TestedApp.Version"];
            var parts = result.Split('.');
            if (parts.Length > 1)
            {
                return $"{parts[0]}.{parts[1]}";
            }

            return result;
        }

        public ulong GetTestRailProjectId()
        {
            return (ulong)Convert.ToInt64(ConfigurationManager.AppSettings["TestRail.ProjectId"]);
        }

        public string GetTestRailUserName()
        {
            return ConfigurationManager.AppSettings["TestRail.UserName"];
        }

        public string GetTestRailPassword()
        {
            return ConfigurationManager.AppSettings["TestRail.Password"];
        }

        public string GetTestRailUrl()
        {
            return ConfigurationManager.AppSettings["TestRail.Url"];
        }

        public bool IsLocal
        {
            get
            {
                var isLocal = GetConfiguration("IsLocal");
                try
                {
                    Console.WriteLine("IsLocal from App.config: " + isLocal);
                    return Boolean.Parse(isLocal);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        private static NameValueCollection GetSection(string key)
        {
           var s = ConfigurationManager.GetSection(key) as NameValueCollection;
           return s;
        }

        private string GetConfiguration(string key)
        {      
            var reader = new AppSettingsReader();
            var val = reader.GetValue(key, typeof(string)).ToString();
            return val;
        }

        public static string GetConnectionString()
        {
            const string connectionStringName = "ProjectConnectionString";
            var connection = ConfigurationManager.ConnectionStrings[connectionStringName]
                .ConnectionString;
            return connection;
        }
    }
}
