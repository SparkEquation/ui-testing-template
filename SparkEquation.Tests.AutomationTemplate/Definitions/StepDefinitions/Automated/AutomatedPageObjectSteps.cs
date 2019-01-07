using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects;
using SparkEquation.Tests.AutomationTemplate.Definitions.StepDefinitions.Common;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SparkEquation.Tests.AutomationTemplate.Definitions.PageObjects.SimplifiedPages;

namespace DummyViewModels
{
	[Binding]
	public class LoginPageSteps : BindingBase<LoginPage>
	{

		public LoginPageSteps(ScenarioContext scenarioContext, SessionConfiguration config) 
            : base(scenarioContext, config)
        {
            
        }
		[When(@"I click LoginPage.Password")]
		public void WhenIClickLoginPagePassword()
		{
			Page.WaitUntil(() => Page.Password.Displayed);
			this.Page.Password.Click();
		}

		[Then(@"I see LoginPage.Password")]
		public void ThenISeeLoginPagePassword()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.Password.Displayed), Page.Password);
		}
		[When(@"I click LoginPage.SubmitButton")]
		public void WhenIClickLoginPageSubmitButton()
		{
			Page.WaitUntil(() => Page.SubmitButton.Displayed);
			this.Page.SubmitButton.Click();
		}

		[Then(@"I see LoginPage.SubmitButton")]
		public void ThenISeeLoginPageSubmitButton()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.SubmitButton.Displayed), Page.SubmitButton);
		}
		[When(@"I click LoginPage.UserName")]
		public void WhenIClickLoginPageUserName()
		{
			Page.WaitUntil(() => Page.UserName.Displayed);
			this.Page.UserName.Click();
		}

		[Then(@"I see LoginPage.UserName")]
		public void ThenISeeLoginPageUserName()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.UserName.Displayed), Page.UserName);
		}
		[When(@"I click LoginPage.Copyright")]
		public void WhenIClickLoginPageCopyright()
		{
			Page.WaitUntil(() => Page.Copyright.Displayed);
			this.Page.Copyright.Click();
		}

		[Then(@"I see LoginPage.Copyright")]
		public void ThenISeeLoginPageCopyright()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.Copyright.Displayed), Page.Copyright);
		}
		[When(@"I click LoginPage.LogOnForm")]
		public void WhenIClickLoginPageLogOnForm()
		{
			Page.WaitUntil(() => Page.LogOnForm.Displayed);
			this.Page.LogOnForm.Click();
		}

		[Then(@"I see LoginPage.LogOnForm")]
		public void ThenISeeLoginPageLogOnForm()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.LogOnForm.Displayed), Page.LogOnForm);
		}
		[When(@"I click LoginPage.Logo")]
		public void WhenIClickLoginPageLogo()
		{
			Page.WaitUntil(() => Page.Logo.Displayed);
			this.Page.Logo.Click();
		}

		[Then(@"I see LoginPage.Logo")]
		public void ThenISeeLoginPageLogo()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.Logo.Displayed), Page.Logo);
		}
		[When(@"I click LoginPage.ForgotForm")]
		public void WhenIClickLoginPageForgotForm()
		{
			Page.WaitUntil(() => Page.ForgotForm.Displayed);
			this.Page.ForgotForm.Click();
		}

		[Then(@"I see LoginPage.ForgotForm")]
		public void ThenISeeLoginPageForgotForm()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.ForgotForm.Displayed), Page.ForgotForm);
		}
		[When(@"I click LoginPage.ForgotPasswordButton")]
		public void WhenIClickLoginPageForgotPasswordButton()
		{
			Page.WaitUntil(() => Page.ForgotPasswordButton.Displayed);
			this.Page.ForgotPasswordButton.Click();
		}

		[Then(@"I see LoginPage.ForgotPasswordButton")]
		public void ThenISeeLoginPageForgotPasswordButton()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.ForgotPasswordButton.Displayed), Page.ForgotPasswordButton);
		}
		[When(@"I click LoginPage.ForgotpasswordUserName")]
		public void WhenIClickLoginPageForgotpasswordUserName()
		{
			Page.WaitUntil(() => Page.ForgotpasswordUserName.Displayed);
			this.Page.ForgotpasswordUserName.Click();
		}

		[Then(@"I see LoginPage.ForgotpasswordUserName")]
		public void ThenISeeLoginPageForgotpasswordUserName()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.ForgotpasswordUserName.Displayed), Page.ForgotpasswordUserName);
		}
		[When(@"I click LoginPage.ForgotpasswordSendButton")]
		public void WhenIClickLoginPageForgotpasswordSendButton()
		{
			Page.WaitUntil(() => Page.ForgotpasswordSendButton.Displayed);
			this.Page.ForgotpasswordSendButton.Click();
		}

		[Then(@"I see LoginPage.ForgotpasswordSendButton")]
		public void ThenISeeLoginPageForgotpasswordSendButton()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.ForgotpasswordSendButton.Displayed), Page.ForgotpasswordSendButton);
		}
		[When(@"I click LoginPage.ForgorpasswordMessage")]
		public void WhenIClickLoginPageForgorpasswordMessage()
		{
			Page.WaitUntil(() => Page.ForgorpasswordMessage.Displayed);
			this.Page.ForgorpasswordMessage.Click();
		}

		[Then(@"I see LoginPage.ForgorpasswordMessage")]
		public void ThenISeeLoginPageForgorpasswordMessage()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.ForgorpasswordMessage.Displayed), Page.ForgorpasswordMessage);
		}
}
	[Binding]
	public class SharedNavigationBlockSteps : BindingBase<SharedNavigationBlock>
	{

		public SharedNavigationBlockSteps(ScenarioContext scenarioContext, SessionConfiguration config) 
            : base(scenarioContext, config)
        {
            
        }
		[When(@"I click SharedNavigationBlock.DashboardButton")]
		public void WhenIClickSharedNavigationBlockDashboardButton()
		{
			Page.WaitUntil(() => Page.DashboardButton.Displayed);
			this.Page.DashboardButton.Click();
		}

		[Then(@"I see SharedNavigationBlock.DashboardButton")]
		public void ThenISeeSharedNavigationBlockDashboardButton()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.DashboardButton.Displayed), Page.DashboardButton);
		}
		[When(@"I click SharedNavigationBlock.UserProfileDropdownButton")]
		public void WhenIClickSharedNavigationBlockUserProfileDropdownButton()
		{
			Page.WaitUntil(() => Page.UserProfileDropdownButton.Displayed);
			this.Page.UserProfileDropdownButton.Click();
		}

		[Then(@"I see SharedNavigationBlock.UserProfileDropdownButton")]
		public void ThenISeeSharedNavigationBlockUserProfileDropdownButton()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.UserProfileDropdownButton.Displayed), Page.UserProfileDropdownButton);
		}
		[When(@"I click SharedNavigationBlock.UserSignoutButton")]
		public void WhenIClickSharedNavigationBlockUserSignoutButton()
		{
			Page.WaitUntil(() => Page.UserSignoutButton.Displayed);
			this.Page.UserSignoutButton.Click();
		}

		[Then(@"I see SharedNavigationBlock.UserSignoutButton")]
		public void ThenISeeSharedNavigationBlockUserSignoutButton()
		{
			Page.VerifyThat(() => Assert.IsTrue(Page.UserSignoutButton.Displayed), Page.UserSignoutButton);
		}
}
}
