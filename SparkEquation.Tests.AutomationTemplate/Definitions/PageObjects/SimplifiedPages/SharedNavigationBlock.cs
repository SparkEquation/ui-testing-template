using SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects.Common;
using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation;
using Objectivity.Test.Automation.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects.SimplifiedPages
{
    // This is an example of simplified page that could be used to address navigation Only, in cases of testing nav panel only
    public class SharedNavigationBlock : BasicNavigationableOpsPage
    {
        [FindsBy(How = How.CssSelector, Using = "a[data-starts-with='/manage/programs']")]
        public IWebElement DashboardButton { get; set; }

        public SharedNavigationBlock(DriverContext driverContext, SessionConfiguration config) : base(driverContext, config)
        {
        }

        public override PageShortname ShortName => PageShortname.OpsNavigationableAbstractPage;
    }
}
