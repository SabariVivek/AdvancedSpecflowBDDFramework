using OpenQA.Selenium;
using SpecflowBDDFramework.Base;

namespace SpecflowBDDFramework.Pages
{
    public class LoginPage : PageBase
    {
        public By Username = By.XPath("//input[@id='email']");
        public By Password = By.XPath("//input[@id='pass']");
        public By SignIn = By.XPath("//button[@class='action login primary']");
        public By MyAccountIdentifier = By.XPath("//span[@data-ui-id='page-title-wrapper']");

        public void EnterCredentials(string username, string password)
        {
            Write(Username, username);
            Write(Password, password);
        }

        public void ClicksOnSignInButton()
        {
            ClickOn(SignIn);
        }

        public void VerifyUserNavigatedToMyAccountDashboardPage()
        {
            PageIdentifier(MyAccountIdentifier);
        }
    }
}