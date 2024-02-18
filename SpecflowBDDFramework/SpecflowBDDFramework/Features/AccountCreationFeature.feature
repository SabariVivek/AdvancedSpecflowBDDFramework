Feature: To create an acccount for the user

@AccountCreation
Scenario: Creating an account with valid data
	When I clicks on the Create an account button
	And I will be taken to Create an account page
	And I fills the mandatory fields in account page
	When I clicks on the Create an account button in Create an account page
	Then User should be taken to the My Account Dashboard Page