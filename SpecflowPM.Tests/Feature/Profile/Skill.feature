Feature: Skill
In order to update my profile 
	As a skill trader 
	I want to add, update and delete the skills that I have


Background: 01 Skill tab
	Given I am in Profile page 
	Given I click on the Skill tab 

@Profile @Skill

Scenario: 02 Add a Skill 
	When I add a new skill 
	Then that skill should be displayed on my listings

Scenario: 03 Edit the existing Skill
	Given One or more Skill is available
	When I edit a skill
	Then I should successfully see the updated skill

Scenario: 04 Delete the existing Skill
	Given One or more Skill is available
	When I delete skill
	Then that particular skill should be deleted successfully

Scenario: 05 Reset a Skill
	When I click on cancel button
	Then that form should successfully reset and hide
