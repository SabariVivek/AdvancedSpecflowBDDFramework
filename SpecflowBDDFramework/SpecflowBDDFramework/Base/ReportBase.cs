using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using SpecflowBDDFramework.Utils;

namespace SpecflowBDDFramework.Base
{
    public class ReportBase
    {
        public static ExtentReports _extentReports = null!;

        [ThreadStatic]
        public static ExtentTest _feature = null!;

        [ThreadStatic]
        public static ExtentTest _scenario = null!;

        public static readonly string FILE_PATH = ReadConfigUtil.GetProjectDirectory() + "\\TestReports\\index.html";

        public static void ExtentReportSetup()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(FILE_PATH);

            htmlReporter.Config.ReportName = "Test Automation Report";
            htmlReporter.Config.DocumentTitle = "Test Automation Report";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);

            _extentReports.AddSystemInfo("Application", "Magento Application");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public static string Screenshot()
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)WebElementBase.Driver;
            return screenshot.GetScreenshot().AsBase64EncodedString;
        }
    }
}