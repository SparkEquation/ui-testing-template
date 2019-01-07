using OpenQA.Selenium;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure
{
    public static class WebElementExtensions
    {
        public static bool ImageIsAccessible(this IWebElement element, IWebDriver driver)
        {
            var imagePresent =
                    (bool)((IJavaScriptExecutor) driver).ExecuteScript(
                        "return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0",
                        element);
            return imagePresent;
        }


    }
}
