using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Module = Autofac.Module;

namespace SpecflowBDDFramework.Base
{
    public class DriverBase : Module
    {
        private static ThreadLocal<IWebDriver> Driver = new();
        public static ConfigBase Config { get; set; } = null!;

        public DriverBase(ConfigBase config)
        {
            Config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            DriverBase.InitDriver(builder);
        }

        public static void InitDriver(ContainerBuilder builder)
        {
            switch (Config.BrowserType)
            {
                case Browser.CHROME:
                    Driver.Value = new ChromeDriver();
                    break;
                case Browser.EDGE:
                    Driver.Value = new EdgeDriver();
                    break;
                case Browser.FIREFOX:
                    Driver.Value = new FirefoxDriver();
                    break;
            }

            Driver.Value!.Manage().Window.Maximize();
            Driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Driver.Value.Url = Config.ApplicationUrl;

            builder.RegisterInstance(Driver.Value);
        }

        public static void DisposeDriver()
        {
            Driver.Value!.Close();
        }
    }

    public enum Browser
    {
        CHROME,
        EDGE,
        FIREFOX
    }
}