using NUnit.Framework;
using SpecflowBDDFramework.Pages;
using TechTalk.SpecFlow;

namespace SpecflowBDDFramework.StepDefinitions
{
    [Binding]
    public class AccountCreationSteps : AccountCreationPage
    {
        [When(@"I clicks on the Create an account button")]
        public void WhenIClicksOnTheCreateAnAccountButton()
        {
            ClicksOnCreateAnAccountInDashBoardPage();
        }

        [When(@"I will be taken to Create an account page")]
        public void WhenIWillBeTakenToCreateAnAccountPage()
        {
            VerifyUserIsInCreateAnAccountPage();
        }

        [When(@"I fills the mandatory fields in account page")]
        public void WhenIFillsTheMandatoryFieldsInAccountPage()
        {
            FillMandatoryFieldsInAccountCreationPage();
        }

        [When(@"I clicks on the Create an account button in Create an account page")]
        public void WhenIClicksOnTheCreateAnAccountButtonInCreateAnAccountPage()
        {
            ClicksOnCreateAnAccountInAccountPage();
        }
    }
}