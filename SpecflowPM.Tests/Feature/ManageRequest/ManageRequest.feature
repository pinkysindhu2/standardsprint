Feature: ManageRequest
	In order to view the request
	As a skill trader
	I want to view the requests

Background: Profile Page
	Given I am in Profile page
	And I hover over Manage Request
@ManageRequest
Scenario: View Received Request
	When I click on Received Requests
	Then it should display Received Requests

Scenario: View Sent Request
	When I click on Sent Requests
	Then it should display Sent Requests