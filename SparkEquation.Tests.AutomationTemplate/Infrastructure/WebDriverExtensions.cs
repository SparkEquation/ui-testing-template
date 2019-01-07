using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace SparkEquation.Tests.AutomationTemplate.Infrastructure
{
    public static class WebDriverExtensions
    {
        public static bool HasElement(this IWebDriver driver, By iClassName)
        {
            try
            {
                driver.FindElement(iClassName);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool HasElement(this IWebElement el, By iClassName)
        {
            try
            {
                el.FindElement(iClassName);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public static bool HasCheckboxRendered(this IWebElement el)
        {
            try
            {
                var enabled = el.Enabled;
                if (!enabled)
                {
                    Console.WriteLine("Element is not displayed");
                }
                return enabled;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element is not found");
                return false;
            }
        }


        public static bool HasElementRendered(this IWebElement el)
        {
            try
            {
                var displayed = el.Displayed;
                if (!displayed)
                {
                    Console.WriteLine("Element is not displayed");
                }
                return el.Displayed;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element is not found");
                return false;
            }
        }

        public static bool HasElementInnerText(this IWebElement el, string txt)
        {
            var txtNorm = txt.Trim().ToLower();
            if (!el.HasElementRendered()) return false;
            var has = el.Text.Trim().ToLower().Contains(txtNorm);
            return has;
        }

        public static bool HasElementImageWithFile(this IWebElement el, string imageFileName)
        {
            var elementImage = el.FindRenderedElementImage();

            if (elementImage == null)
            {
                return false;
            }
            
            var attrVal = elementImage.GetAttribute("src");
            
            return attrVal.Trim().Contains(imageFileName.Trim());
        }

        public static bool HasElementImageWithFile(this IWebElement el, Regex imageFileName)
        {
            var elementImage = el.FindRenderedElementImage();

            if (elementImage == null)
            {
                return false;
            }
            
            var attrVal = elementImage.GetAttribute("src");
            
            return imageFileName.IsMatch(attrVal.Trim());
        }

        public static IWebElement FindRenderedElementImage(this IWebElement el)
        {
            if (!el.HasElementRendered())
            {
                return null;
            }

            if (el.TagName == "img")
            {
                return el;
            }

            var source = el.FindElement(By.Name("img"));

            return source.HasElementRendered() ? source : null;
        }

        public static bool HasElementHrefWithText(this IWebElement el, string text)
        {
            if (!el.HasElementRendered()) return false;
            var source = el;
            if (el.TagName != "a")
            {
                if (el.HasElement(By.Name("a")))
                {
                    source = el.FindElement(By.Name("a"));
                    if (!source.HasElementRendered()) return false;
                }
                else
                {
                    return false;
                }
            }
            var attrVal = source.GetAttribute("href");
            var has = attrVal.Trim().Contains(text.Trim());
            return has;
        }

        public static void DropFiles(this IWebElement target, IWebDriver driver, IEnumerable<string> filePaths, int offsetX = 0, int offsetY = 0) 
        {
            foreach (var path in filePaths)
            {
                DropFile(target, driver, path, offsetX, offsetY);
            }
        }

        public static void DropFile(this IWebElement target, IWebDriver driver, string filePath, int offsetX = 0, int offsetY = 0) 
        {
            var fullPath = Path.Combine(ConfigurationProvider.GetBaseFilePath(), filePath);

            var jsExecutor = (IJavaScriptExecutor)driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            const string scriptForDropFile = @"
                var target = arguments[0],
                    offsetX = arguments[1],
                    offsetY = arguments[2],
                    document = target.ownerDocument || document,
                    window = document.defaultView || window;

                var input = document.createElement('input');
                input.type = 'file';
                input.style.display = 'none';

                input.onchange = function () {
                  target.scrollIntoView(true);

                  var rect = target.getBoundingClientRect(),
                      x = rect.left + (offsetX || (rect.width >> 1)),
                      y = rect.top + (offsetY || (rect.height >> 1)),
                      dataTransfer = { files: this.files };

                  ['dragenter', 'dragover', 'drop'].forEach(function (name) {
                    var event = new MouseEvent(name, {
                      clientX: x,
                      clientY: y,
                    });

                    event.dataTransfer = dataTransfer;
                    target.dispatchEvent(event);
                  });

                  setTimeout(function () {
                    document.body.removeChild(input);
                  }, 25);
                };

                document.body.appendChild(input);
                return input;
            ";

            var input = (IWebElement)jsExecutor.ExecuteScript(scriptForDropFile, target, offsetX, offsetY);
            input.SendKeys(fullPath);

            wait.Until(ExpectedConditions.StalenessOf(input));
        }

        public static bool HasClass(this IWebElement el, string className)
        {
            var classAttrib = el.GetAttribute("class");
            return classAttrib.Contains(className);
        }

        public static bool HasClass(this IList<IWebElement> el, string className)
        {
            return el.All(e => e.HasClass(className));
        }


        public static void SetAttribute(this IWebElement element, string attributeName, string value)
        {
            var wrappedElement = element as IWrapsDriver;
            if (wrappedElement == null)
                throw new ArgumentException("element", "Element must wrap a web driver");

            var driver = wrappedElement.WrappedDriver;
            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");

            javascript.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, attributeName, value);
        }

        public static void SelectByText(this IWebElement element, string text)
        {
            if (!element.HasElementRendered()) return;
            var selectEl = new SelectElement(element);
            if (selectEl.AllSelectedOptions[0].Text.Contains(text)) return;
            if (selectEl.Options.Any(o => o.Text.Contains(text)))
            {
                selectEl.SelectByText(text);
            }
            else
            {
                if (selectEl.Options.Any())
                {
                    selectEl.SelectByIndex(0);
                }
            }
        }

        public static void ScrollTo(this IWebDriver driver, int y)
        {
            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
            javascript.ExecuteScript($"window.scrollTo(1,{y})");

        }


        public static void ScrollDown(this IWebDriver driver)
        {
            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
            javascript.ExecuteScript("window.scrollTo(1,6000)");
        }

        public static void ScrollUp(this IWebDriver driver)
        {
            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("element", "Element must wrap a web driver that supports javascript execution");
            javascript.ExecuteScript("window.scrollTo(0,0)");
        }
    }
}
