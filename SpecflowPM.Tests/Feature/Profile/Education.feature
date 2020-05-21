Feature: Education
In order to update my profile 
	As a skill trader
	I want to add, update and delete my Education details


Background: 01 Education tab
	Given I am in Profile page
	And I click on the Education

@Profile @Education

Scenario: 02 Add a Education 
	When I add a new education
	Then that education should be displayed on my listings

Scenario: 03 Edit the existing Education
	Given One or more Education is available
	When I edit a education
	Then I should successfully see the updated education

Scenario: 04 Delete the existing Education
	Given One or more Education is available
	When I delete education
	Then that particular education should be deleted successfully

Scenario: 05 Cancel a Education
	When I click on cancel button
	Then that form should successfully reset and hide

