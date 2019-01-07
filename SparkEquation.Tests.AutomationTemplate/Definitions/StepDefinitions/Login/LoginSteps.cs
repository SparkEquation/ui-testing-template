using SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects;
using SparkEquation.Tests.AutomationTemplate.Definitions.StepDefinitions.Common;
using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation;
using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using TechTalk.SpecFlow;

namespace SparkEquation.Tests.AutomationTemplate.Definitions.StepDefinitions.Login
{
    [Binding]
    public class LoginSteps : BindingBase<PageObjects.LoginPage>
    {
        public LoginSteps(ScenarioContext scenarioContext, SessionConfiguration config) 
            : base(scenarioContext, config)
        {
            
        }

        protected override string PageKey => PageShortname.LoginPage.ToString();

        private void Login(string userName, string password)
        {
            Page.UserName.SendKeys(userName);
            Page.Password.SendKeys(password);

            Page.SubmitButton.Click();
        }

        #region Given

        [Given(@"I Logged in as OpsAdmin")]
        public void GivenILoggedInAsOpsAdmin()
        {
            PortalNavigator.NavigateToPage(_driverContext, PageShortname.LoginPage, PortalNavigator.BaseUrl);
            var login = OpsAuthData.Login;
            var pass = OpsAuthData.Password;
            Login(login, pass);
        }

        #endregion

        #region When

        [When(@"I Login as Talent")]
        public void LoginAsTalent()
        {
            var login = TalentAuthData.Login;
            var pass = TalentAuthData.Password;
            Login(login, pass);
        }

        [When(@"I Login as OpsAdmin")]
        public void LoginAsOpsAdmin()
        {
            var login = OpsAuthData.Login;
            var pass = OpsAuthData.Password;
            Login(login, pass);
        }

        [When(@"I enter valid name into restore password form")]
        public void ThenIEnterValidNameIntoPasswordForm()
        {
            Page.ForgotpasswordUserName.SendKeys(OpsAuthData.Login);
        }
        
        #endregion

    }
}
