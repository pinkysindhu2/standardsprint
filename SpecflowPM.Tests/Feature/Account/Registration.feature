Feature: Registration
	Feature related to Account services
	As a skill trader
	I want to register

@Account
Scenario Outline: Register as a skill trader
	Given I visit to Home page
	And I click on Join button  
	When I fill the personal details <FirstName>,<LastName>,<Email>,<Password> and <Confirm Password>
	Then it should tell you to verify account (Unless the email is already taken)
	Examples: 
	| FirstName | LastName | Email                  | Password | Confirm Password |
	| Pinky     | Sindhu   | sindhupinky2@gmail.com | abcd123  | abcd123          |