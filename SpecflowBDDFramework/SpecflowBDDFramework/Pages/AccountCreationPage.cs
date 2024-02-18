using OpenQA.Selenium;
using SpecflowBDDFramework.Base;
using SpecflowBDDFramework.Utils;

namespace SpecflowBDDFramework.Pages
{
    public class AccountCreationPage : PageBase
    {
        public By CreateAnAccountInDashboardPage = By.XPath("//div[@class='panel header']//a[normalize-space()='Create an Account']");
        public By FirstName = By.XPath("//input[@id='firstname']");
        public By LastName = By.XPath("//input[@id='lastname']");
        public By Email = By.XPath("//input[@id='email_address']");
        public By Password = By.XPath("//input[@id='password']");
        public By ConfirmPassword = By.XPath("//input[@id='password-confirmation']");
        public By CreateAnAccountInAccountPage = By.XPath("//button[@title='Create an Account']");

        public void ClicksOnCreateAnAccountInDashBoardPage()
        {
            ClickOn(CreateAnAccountInDashboardPage);
        }

        public void VerifyUserIsInCreateAnAccountPage()
        {
            PageIdentifier(FirstName);
        }

        public void FillMandatoryFieldsInAccountCreationPage()
        {
            string password = FakerUtil.Password();

            Write(FirstName, FakerUtil.FirstName());
            Write(LastName, FakerUtil.LastName());
            Write(Email, FakerUtil.Email());
            Write(Password, password);
            Write(ConfirmPassword, password);
        }

        public void ClicksOnCreateAnAccountInAccountPage()
        {
            ClickOn(CreateAnAccountInAccountPage);
        }
    }
}