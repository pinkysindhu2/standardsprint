Feature: ShareSkill
	In order to trade my skills 
	As a skill trader
	I want to create, update and delete Services

Background: Profile Page
		Given I am in Profile page

@ShareSkill
Scenario: 01 Add a new Service
	Given I click on ShareSkill button
	When I add service
	Then that service details should be displayed on my listing under ManageListing page

Scenario: 02 Cancel a new Service
	Given I click on ShareSkill button
	When I cancel skill 
	Then that skill should be cancelled and not be displayed under ManageListing page

Scenario: 03 Edit the existing Service
	Given I click on the ManageListings
	When I edit a service
	Then that service should be update with new details on my listings under ManageListing page

Scenario: 04 View a Service
	Given I click on the ManageListings
	When I view a service
	Then Service should be displayed in more detailed information

Scenario: 05 Delete a Service
	Given I click on the ManageListings
	When I delete a service
	Then that service should not be displayed on my listings under ManageListing page



