using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium.Support.PageObjects;

namespace SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects.Common
{
    public abstract class ProjectBaseAbstractPage : ProjectPageBase
    {
        protected ProjectBaseAbstractPage(DriverContext driverContext, SessionConfiguration config) : base(driverContext, config)
        {
            PageFactory.InitElements(Driver, this);
        }

        protected string GetBaseUrl()
        {
            return PortalNavigator.BaseUrl;
        }
        
        public abstract override PageShortname ShortName { get; }

        public string PageSubUrl { get; protected set; }

        public virtual ProjectBaseAbstractPage NavigateTo()
        {
            var url = GetBaseUrl();
            Driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}
