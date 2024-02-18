using SpecflowBDDFramework.Pages;

namespace SpecflowBDDFramework.Base
{
    public class PageBase : WebElementBase
    {
        public static LoginPage _LoginPage = new LoginPage();
        public static AccountCreationPage _AccountCreationPage = new AccountCreationPage();
    }
}