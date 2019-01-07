// <copyright file="ProjectPageBase.cs" company="Objectivity Bespoke Software Specialists">
// Copyright (c) Objectivity Bespoke Software Specialists. All rights reserved.
// </copyright>
// <license>
//     The MIT License (MIT)
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// </license>

using System;
using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation;
using SparkEquation.Tests.AutomationTemplate.Infrastructure;
using SparkEquation.Tests.AutomationTemplate.Infrastructure.Navigation;
using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using OpenQA.Selenium;

namespace Objectivity.Test.Automation.Tests.PageObjects
{
    public partial class ProjectPageBase
    {
        protected readonly SessionConfiguration Configuration;

        public ProjectPageBase(DriverContext driverContext, SessionConfiguration configuration)
        {
            DriverContext = driverContext;
            Driver = driverContext.Driver;

            Configuration = configuration;
        }

        protected IWebDriver Driver { get; set; }

        protected DriverContext DriverContext { get; set; }

        private const double AwaitCheckSpanSec = 0.1;
        private const int AwaitCheckCount = 600;

        public virtual PageShortname ShortName { get; }

        public void WaitForLoading(By spinnerSelector)
        {
            while (Driver.HasElement(spinnerSelector))
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AwaitCheckSpanSec);
            }
        }

        public void WaitUntil(By spinnerSelector, int attempts = AwaitCheckCount)
        {
            while (!Driver.HasElement(spinnerSelector) && attempts > 0)
            {
                attempts--;
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AwaitCheckSpanSec);
            }
        }

        public void WaitForElementToHide(IWebElement element, int attempts = AwaitCheckCount)
        {
            while (element.HasElementRendered() && attempts > 0)
            {
                attempts--;
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AwaitCheckSpanSec);
            }
        }

        public void WaitForElementToRender(IWebElement element, int attempts = AwaitCheckCount)
        {
            while (!element.HasElementRendered() && attempts > 0)
            {
                attempts--;
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AwaitCheckSpanSec);
            }
        }

        public void WaitUntil(Func<bool> checker, int attempts = AwaitCheckCount)
        {
            Func<bool> checkerInner = () =>
            {
                try
                {
                    return !checker.Invoke();
                }
                catch (NoSuchElementException e)
                {
                    return true;
                }
            };
            while (checkerInner() && attempts > 0)
            {
                attempts--;
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AwaitCheckSpanSec);
            }
        }

        public void VerifyThat(Action verifyAction, IWebElement waitForElementToRender = null, IWebElement waitForElementToHide = null, bool saveScreenShot = false,
            bool savePageSource = false)
        {
            if (waitForElementToHide != null)
            {
                WaitForElementToHide(waitForElementToHide);
            }

            if (waitForElementToRender != null)
            {
                WaitForElementToRender(waitForElementToRender);
            }

            Verify.That(DriverContext, verifyAction, saveScreenShot, savePageSource);
        }

        public void VerifyAddress(string subUrlTocheck, int attempts = 600)
        {
            WaitUntil(() =>
            {
                var urlObj = new Uri(DriverContext.Driver.Url);
                return urlObj.AbsolutePath + (urlObj.Fragment ?? "") == subUrlTocheck;
            }, attempts);
            var urlObject = new Uri(DriverContext.Driver.Url);
            Verify.That(DriverContext, () => Assert.AreEqual(subUrlTocheck, new Uri(DriverContext.Driver.Url).AbsolutePath + (urlObject.Fragment ?? "")), false, false);
        }
    }
}
