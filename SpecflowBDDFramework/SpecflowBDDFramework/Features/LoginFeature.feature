Feature: To login into the application

@Login
Scenario: To login into the application with valid credentials
	Given I enters the username as "sabarivivek7@gmail.com" and password as "Sabari@123"
	When I clicks on the signin button
	Then User should be taken to the My Account Dashboard Page