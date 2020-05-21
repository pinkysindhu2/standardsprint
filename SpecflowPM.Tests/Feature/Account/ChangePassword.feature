Feature: ChangePassword
	Feature related to Account services
	As a skill trader
	I want to change my password

@Password
Scenario Outline: Change password as a skill trader
	Given I am in Profile page 
	And I click change password
	When I enter <CurrentPassword> and <NewPassword>
	Then NewPassword should get saved
	Examples: 
	| CurrentPassword | NewPassword |
	| abcd123         | abcd1234    |