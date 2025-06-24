using Core.Drivers;
using Core.Element;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Test.Components;

namespace Test.Extensions
{
    public static class WebComponentExtensions
    {
        public static WebDriverWait Wait() => BrowserFactory.GetDriverWait();

         public static void ClickSubElement(this CalendarObject parentWebbObject, WebObject childWebObject)
        {
            WebDriverWait wait = Wait();

            // Wait for the parent element to be clickable
            IWebElement parent = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(parentWebbObject.By));

            // Wait for the child element inside the parent
            IWebElement child = wait.Until(drv =>
            {
                IWebElement el = parent.FindElement(childWebObject.By);
                return (el != null && el.Displayed && el.Enabled) ? el : null;
            });

            child.Click();

        }
        public static IWebElement WaitSubElementToBeVisible(this CalendarObject parentWebbObject, WebObject childWebObject)
        {
            WebDriverWait wait = Wait();

            // Wait for the parent element to be clickable
            IWebElement parent = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(parentWebbObject.By));

            // Wait for the child element inside the parent
            IWebElement child = wait.Until(drv =>
            {
                IWebElement el = parent.FindElement(childWebObject.By);
                return (el != null && el.Displayed) ? el : null;
            });
            return child;
        }
        public static IWebElement WaitSubElementToBeClickable(this CalendarObject parentWebbObject, WebObject childWebObject)
        {
            WebDriverWait wait = Wait();

            // Wait for the parent element to be clickable
            IWebElement parent = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(parentWebbObject.By));

            // Wait for the child element inside the parent
            IWebElement child = wait.Until(drv =>
            {
                IWebElement el = parent.FindElement(childWebObject.By);
                return (el != null && el.Displayed && el.Enabled) ? el : null;
            });
            return child;
        }
    }
}