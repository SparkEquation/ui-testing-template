using SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects.Common;
using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation;
using Objectivity.Test.Automation.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects
{
    // Example of login page object
    public class LoginPage : ProjectBaseAbstractPage
    {
        #region Page object

        [FindsBy(How = How.Id, Using = "Password")]
        internal IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "SignIn")]
        internal IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "UserName_1")]
        internal IWebElement UserName { get; set; }

        [FindsBy(How = How.ClassName, Using = "copyright")]
        internal IWebElement Copyright { get; set; }

        [FindsBy(How = How.Id, Using = "logonform")]
        internal IWebElement LogOnForm { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div.header > img")]
        internal IWebElement Logo { get; set; }

        [FindsBy(How = How.Id, Using = "forgotform")]
        internal IWebElement ForgotForm { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#logonform > span > a")]
        internal IWebElement ForgotPasswordButton { get; set; }

        [FindsBy(How = How.Id, Using = "UserName_2")]
        internal IWebElement ForgotpasswordUserName { get; set; }

        [FindsBy(How = How.Id, Using = "ResetPassword")]
        internal IWebElement ForgotpasswordSendButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "forgot-message")]
        internal IWebElement ForgorpasswordMessage { get; set; }

        #endregion

        #region Infrastructure
        public override PageShortname ShortName => PageShortname.LoginPage;

        public const string LogoUrl = "/partner-assets/";

        public string CopyrightText
        {
            get { return "© TestCorp Inc " + System.DateTime.Now.Year; }
        }

        public LoginPage(DriverContext driverContext, SessionConfiguration config) 
            : base(driverContext, config)
        {
        }

        #endregion
    }
}
