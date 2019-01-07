using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using Objectivity.Test.Automation.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects.Common
{
    //An example page shown how to use shared UI elements like navigation among multiple PageObjects via base class which is this one
    public abstract class BasicNavigationableOpsPage : ProjectBaseAbstractPage
    {
        [FindsBy(How = How.Id, Using = "uprofile-username")]
        public IWebElement UserProfileDropdownButton { get; set; }

        [FindsBy(How = How.Id, Using = "uprofile-signout")]
        public IWebElement UserSignoutButton { get; set; }

        protected BasicNavigationableOpsPage(DriverContext driverContext, SessionConfiguration config) : base(driverContext, config)
        {
        }
    }
}
