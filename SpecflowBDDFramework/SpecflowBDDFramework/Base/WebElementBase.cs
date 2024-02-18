using Autofac;
using OpenQA.Selenium;

namespace SpecflowBDDFramework.Base
{
    public class WebElementBase
    {
        public static IWebDriver Driver => ContainerBase.Container.Resolve<IWebDriver>();

        public void Write(By element, string elementValue)
        {
            Driver.FindElement(element).SendKeys(elementValue);
        }

        public void ClickOn(By element)
        {
            Driver.FindElement(element).Click();
        }

        public void PageIdentifier(By element)
        {
            if (Driver.FindElement(element).Displayed)
            {
                Console.WriteLine("Navigated to the given page");
            }
            else
            {
                throw new Exception("Unable to navigate to the given page");
            }
        }
    }
}