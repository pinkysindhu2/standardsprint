Feature: Certification
In order to update my profile 
	As a skill trader
	I want to add, update and delete my Certifications that I have 


Background: 01 Cetrificate tab
	Given I am in Profile page 
	And I click on the Certification tab 

@Profile @Certification

Scenario: 02 Add a Certification 	
	When I add a new certification
	Then that certification should be successfully displayed on my listings

Scenario: 03 Edit the existing Certification
	Given One or more Certification is available
	When I edit a certification
	Then I should successfully see the updated certification

Scenario: 04 Delete the existing Certification
	Given One or more Certification is available
	When I delete a certification
	Then that particular certification should be deleted successfully

Scenario: 05 Cancel a Certification
	When I click on cancel button
	Then that form should successfully reset and hide
