Feature: Description
In order to update my profile 
	As a skill trader
	I want to add a short profile description

Background: 01 Description tab
	Given I am in Profile page
	And I click on Edit button beside Description

@Profile @Description

Scenario: 02 Add a Description
	When I save a short summary 
	Then that short summary should be displayed on my listings

Scenario: 03 Update a Description 
	When I update description
	Then that description should be successfully updated

Scenario: 04 Reset a Description
	When I click on cancel button
	Then that form should successfully reset and hide


