Feature: Language
In order to update my profile 
	As a skill trader 
	I want to add, update and delete the languages that I know

Background: 01 Language tab
	Given I am in Profile page 
	And I click on the language tab

@Profile @Language

Scenario: 02 Add a Language 
	When I add a new language 
	Then that language should be displayed on my listings

Scenario: 03 Edit the existing Language
	Given One or more language is available
	When I edit a lanaguage
	Then I should successfully see the updated lanaguage

Scenario: 04 Delete the existing Language
	Given One or more language is available
	When I delete a lanaguage
	Then that particular language should be deleted successfully

Scenario: 05 Cancel a Language
	When I click on cancel button
	Then that form should successfully reset and hide


