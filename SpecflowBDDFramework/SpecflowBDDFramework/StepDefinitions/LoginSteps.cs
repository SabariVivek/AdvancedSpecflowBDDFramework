using AventStack.ExtentReports.Gherkin.Model;
using SpecflowBDDFramework.Pages;
using TechTalk.SpecFlow;

namespace SpecflowBDDFramework.StepDefinitions
{
    [Binding]
    public class LoginSteps : LoginPage
    {
        [Given(@"I enters the username as ""([^""]*)"" and password as ""([^""]*)""")]
        public void GivenIEntersTheUsernameAsAndPasswordAs(string username, string password)
        {
            EnterCredentials(username, password);
        }

        [When(@"I clicks on the signin button")]
        public void WhenIClicksOnTheSigninButton()
        {
            ClicksOnSignInButton();
        }

        [Then(@"User should be taken to the My Account Dashboard Page")]
        public void ThenUserShouldBeTakenToTheMyAccountDashboardPage()
        {
            VerifyUserNavigatedToMyAccountDashboardPage();
        }
    }
}
