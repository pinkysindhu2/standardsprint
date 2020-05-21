Feature: Login
	Feature related to Account services
	As a skill trader
	I want to Login

@Login
Scenario Outline: Login as trader
	Given I visit to Home page
	And I click on Sigin button  
	When I enter <Email> and <Password>
	Then I should be in Profile page
Examples: 
	| Email                  | Password |
	| sindhupinky2@gmail.com | abcd123  |
