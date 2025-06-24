using Core.Drivers;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

namespace Core.Element
{
    public static class WebObjectExtension
    {
        // public static WebDriverWait Wait() => BrowserFactory.GetDriverWait();

        public static IWebElement WaitForElementToBeVisible(this WebObject webObject)
        {
            // Wait().IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            // return Wait().Until(ExpectedConditions.ElementIsVisible(webObject.By));

            // var Wait = new WebDriverWait(BrowserFactory.GetWebDriver(), );
            WebDriverWait webDriverWait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(10));
            webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return BrowserFactory.GetDriverWait().Until(ExpectedConditions.ElementIsVisible(webObject.By));
        }
        public static List<IWebElement> WaitForAllElementsToBeVisible(this WebObject webObjects)
        {
            WebDriverWait webDriverWait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(10));
            webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return webDriverWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(webObjects.By)).ToList();
        }
        public static IWebElement WaitForElementToBeClickable(this WebObject webObject)
        {
            WebDriverWait webDriverWait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(10));
            webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return webDriverWait.Until(ExpectedConditions.ElementToBeClickable(webObject.By));
        }
        public static string GetTextFromElement(this WebObject webObject)
        {
            IWebElement element = IsElementDisplayed(webObject) ? WaitForElementToBeVisible(webObject) : null;
            if (element != null)
            {
                return element.Text;
            }
            return string.Empty;
        }
        public static List<string> GetTextFromAllElements(this WebObject webObject)
        {
            List<string> textList = new List<string>();
            List<IWebElement> elements = WaitForAllElementsToBeVisible(webObject).ToList();
            foreach (var element in elements)
            {
                textList.Add(element.Text);
            }
            return textList;
        }
        public static bool IsElementDisplayed(this WebObject webObject)
        {
            WebDriverWait webDriverWait = new WebDriverWait(BrowserFactory.GetWebDriver(), TimeSpan.FromSeconds(10));
            webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return webDriverWait.Until(ExpectedConditions.ElementIsVisible(webObject.By)).Displayed;
        }
        public static void ClickOnElement(this WebObject webObject)
        {
            IWebElement element = WaitForElementToBeClickable(webObject);
            element.Click();
        }
        public static void EnterText(this WebObject webObject, string text, bool clearTest = true)
        {
            IWebElement element = WaitForElementToBeClickable(webObject);
            if (clearTest)
            {
                element.Clear();
            }
            element.SendKeys(text);
        }
        //Extra
        
        
    }
}