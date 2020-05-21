Feature: Logout
	Feature related to Account services
	As a skill trader
	I want to Logout

@Logout
Scenario: Logout as a skill trader
	Given I am in Profile page
	When I click on Logout
	Then I should be in Home page
