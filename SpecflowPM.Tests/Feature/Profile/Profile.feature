Feature: Profile
	In order to update my profile
	As a skill trader
	I want to update my profile page

Background: Profile Page
	Given I am in Profile page 

@Profile
Scenario: Update Availability
	When I update Availability
	Then the result should be updated beside Availability

Scenario: Update Hours
	When I update Hours
	Then the result should be updated beside Hours

Scenario: Update Earn Target
	When I update Earn Target
	Then the result should be updated beside Earn Target