using System;
using System.IO;
using System.Linq;

using Core.Drivers;
using Core.Reports;
using Core.Utils;

using NUnit.Framework;

using Reqnroll;

using Service.Const;

using Test.Extensions;
using Test.PageObjects;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace Test.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            TestContext.Progress.WriteLine("================> Global OneTimeSetUp");
            ConfigurationUtils.ReadConfiguration("Configurations\\appsettings.json");
            var reportPaths = new string[]{
                Directory.GetCurrentDirectory()+"\\TestResults\\Latest-test.html",
                Directory.GetCurrentDirectory()+$"\\TestResults\\Test-{DateTime.Now.ToString("yyyyMMdd HHmmss")}.html"
            };
            ExtentReportHelper.InitualizeReport(reportPaths, FileConst.REPORT_CONFIG_FILE.GetAbsolutePath());
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportHelper.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            ExtentReportHelper.CreateFeature(featureContext.FeatureInfo.Title);
        }
        [AfterFeature]
        public static void AfterFeature()
        {

        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext sContext)
        {
            sContext.DefineScenarioNameIntoReport();
        }
        [AfterScenario]
        public void AfterScenario()
        {

        }
        [BeforeScenario("@web")]
        public void BeforeWebScenario()
        {
            var args = ConfigurationUtils.GetBrowserArgs("BrowserArgs");
            BrowserFactory.InitializeDriver(ConfigurationUtils.GetConfigurationByKey("Browser"), args.ToArray());
            DriverUtils.GoToUrl(ConfigurationUtils.GetConfigurationByKey("TestUrl"));
        }
        [BeforeScenario("@createProject")]
        public void BeforeScenarioCreateProjectTag()
        {

            LoginPage loginPage = new LoginPage();
            loginPage.Login(ConfigurationUtils.GetConfigurationByKey("Username"), ConfigurationUtils.GetConfigurationByKey("Password"));
            CreateProjectPopup createProjectPopup = new CreateProjectPopup();
            createProjectPopup.OpenCreateProjectPopup();

        }

        [AfterScenario("@createProject")]
        public void AfterScenarioCreateProjectTag()
        {
            ProjectDetailPage projectDetailPage = new ProjectDetailPage();
            projectDetailPage.DeleteProject();
        }
        [AfterScenario("@web")]
        public void AfterWebScenario()
        {
            DriverUtils.CloseAndCleanUp();
        }
        [AfterStep]
        // [System.Obsolete]
        public void AfterStep()
        {
            _scenarioContext.UpdateBDDStepInfoIntoReport(_featureContext.FeatureInfo.Title);
        }

    }
}