using Autofac;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using SpecflowBDDFramework.Base;
using SpecflowBDDFramework.Resources;
using SpecflowBDDFramework.Utils;
using TechTalk.SpecFlow;

namespace SpecflowBDDFramework.Hooks
{
    [Binding]
    public sealed class MyHooks : ContainerBase
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ReportBase.ExtentReportSetup();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ReportBase.ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            ReportBase._feature = ReportBase._extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            SetupAutofac();

            ReportBase._scenario = ReportBase._feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverBase.DisposeDriver();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            // When Scenario Passed...
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    ReportBase._scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    ReportBase._scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    ReportBase._scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    ReportBase._scenario.CreateNode<And>(stepName);
                }
            }

            // When Scenario Failed...
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    ReportBase._scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromBase64String(ReportBase.Screenshot()).Build());
                }
                else if (stepType == "When")
                {
                    ReportBase._scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                         MediaEntityBuilder.CreateScreenCaptureFromBase64String(ReportBase.Screenshot()).Build());
                }
                else if (stepType == "Then")
                {
                    ReportBase._scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromBase64String(ReportBase.Screenshot()).Build());
                }
                else if (stepType == "And")
                {
                    ReportBase._scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromBase64String(ReportBase.Screenshot()).Build());
                }
            }
        }

        public static void SetupAutofac()
        {
            // Initializing the Autofac Container...
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DriverBase(ReadConfigUtil.ReadConfig(TestDataService.CORE)));

            // Building the Autofac Container...
            Container = builder.Build();
        }
    }
}