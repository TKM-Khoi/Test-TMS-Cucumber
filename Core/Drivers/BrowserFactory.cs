using Core.Utils;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Core.Drivers
{
    public static class BrowserFactory
    {
        private static ThreadLocal<IWebDriver> AsyncLocalWebDriver = new ThreadLocal<IWebDriver>();
        private static ThreadLocal<WebDriverWait> AsyncLocalWait = new ThreadLocal<WebDriverWait>();
        public static void InitializeDriver(string browserName, string[]? args = null)
        {
            switch (browserName.ToLower())
            {
                case "chrome":
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                        ChromeOptions chromeOptions = new ChromeOptions();
                        if (args != null && args.Length != 0)
                        {
                            foreach (var arg in args)
                            {
                                chromeOptions.AddArguments(arg);
                            }
                        }
                        ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
                        AsyncLocalWebDriver.Value = chromeDriver;
                        AsyncLocalWait.Value = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(Int32.Parse(ConfigurationUtils.GetConfigurationByKey("WebDriver.Wait.Time"))));
                        break;
                    }
                case "firefox":
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("test-type");
                        chromeOptions.AddArguments("--no-sandbox");
                        if (args != null && args.Length > 0)
                        {
                            chromeOptions.AddArguments(args);
                        }
                        ChromeDriver chromeDriver = new(chromeOptions);
                        AsyncLocalWebDriver.Value = chromeDriver;
                        AsyncLocalWait.Value = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
                        break;
                    }
                default: throw new ArgumentException("InitualizeDriver: Not a valid driver");
            }
        }
        public static void CleanUpWebDriver()
        {
            if (GetWebDriver() != null)
            {
                GetWebDriver().Quit();
                GetWebDriver().Dispose();
            }
        }
        public static IWebDriver GetWebDriver()
        {
            return AsyncLocalWebDriver.Value;
        }
        public static WebDriverWait GetDriverWait()
        {
            return AsyncLocalWait.Value;
        }
    }
}