using Objectivity.Test.Automation.Common;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation
{
    public class PortalNavigator
    {
        //TODO: Should be moved to a dynamic config
        public static string BaseUrl
        {
            get { return "https://stage.example.com"; }
        }

        public static void NavigateToPage(DriverContext driver, PageShortname pageName, string baseUrl, string subUrl = "")
        {
            var url = pageName.GetUrl(baseUrl) + subUrl;
            var currUrl = driver.Driver.Url;
            if (currUrl != url)
            {
                driver.Driver.Navigate().GoToUrl(url);
            }
        }
    }
}
