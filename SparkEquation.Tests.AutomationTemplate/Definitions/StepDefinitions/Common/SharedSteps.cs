using System;
using System.Linq;
using SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects;
using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation;
using TechTalk.SpecFlow;

namespace SparkEquation.Tests.AutomationTemplate.Definitions.StepDefinitions.Common
{
    /// <summary>
    /// A class for steps shared between multiple pages, like logging in, or switching to a new browser tab
    /// </summary>
    [Binding]
    public class SharedSteps : BindingBase<PageObjects.LoginPage>
    {
        public SharedSteps(ScenarioContext scenarioContext, SessionConfiguration config) 
            : base(scenarioContext, config)
        {

        }

        protected override string PageKey => PageShortname.LoginPage.ToString();

        [Given(@"""(.*)"" is opened")]
        [When(@"I open ""(.*)""")]
        public void GivenDefaultPageIsNavigated(string pageShortName)
        {
            var pageShort = (PageShortname) Enum.Parse(typeof(PageShortname), pageShortName);
            PortalNavigator.NavigateToPage(_driverContext, pageShort, PortalNavigator.BaseUrl);
        }

        [Given("Logout page")]
        [When("I logout")]
        public void Logout()
        {
            var rootPage = PageShortname.RootPage;
            PortalNavigator.NavigateToPage(_driverContext, rootPage, PortalNavigator.BaseUrl);
            var page = new LoginPage(_driverContext, Configuration);
            _scenarioContext.Set(page, rootPage.ToString());
        }

        [Then(@"Page path is ""(.*)""")]
        public void PageAddressIs(string path)
        {
            Page.VerifyAddress(path);
        }

        [Then(@"Page shortname is ""(.*)""")]
        public void PageNameIs(string name)
        {
            var subUrl = name.GetSubUrlByShortName();
            var urlObject = new Uri(_driverContext.Driver.Url);
            var url = urlObject.AbsolutePath + (urlObject.Fragment ?? "");
            Page.VerifyAddress(subUrl);
        }

        [When(@"I switch to newly open tab")]
        public void SwitchToLastTab()
        {
            var lastHandle = _driverContext.Driver.WindowHandles.Last();
            _driverContext.Driver.SwitchTo().Window(lastHandle);
        }
    }
}
