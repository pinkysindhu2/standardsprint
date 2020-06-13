Feature: ShareSkill
	In order to trade my skills 
	As a skill trader
	I want to create, update and delete Services

Background: Profile Page
		Given I am in Profile page

@ShareSkill
Scenario: Add a new Service
	Given I click on ShareSkill button
	When I add service
	Then The service should be displayed on my listing under ManageListing page

Scenario: Cancel a new Service
	Given I click on ShareSkill button
	When I cancel service 
	Then The service should be cancelled and not be displayed under ManageListing page

Scenario: Edit the existing Service
	Given I click on the ManageListings
	When I edit a service
	Then The service should be updated on my listings under ManageListing page

Scenario: View a Service
	Given I click on the ManageListings
	When I view a service
	Then The service should be displayed with more detailed information

Scenario: Delete a Service
	Given I click on the ManageListings
	When I delete a service
	Then The service should be deleted and not be displayed on my listings under ManageListing page



