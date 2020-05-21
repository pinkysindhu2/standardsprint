Feature: Chat
	In order to view the chat
	As a skill trader
	I want to chat and view chat history

Background: Profile Page
	Given I am in Profile page

@Chat
Scenario: Chat to any trader
	Given I click on the ManageListings
	When I view a service 
	And I click on Chat button
	Then It should display chat for that listing

Scenario: View chat history
	When I click on Chat tab
	Then It should display chat history