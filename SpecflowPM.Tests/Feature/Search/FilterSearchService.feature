Feature: FilterSearchService
	Feature related to Search service/skill Result 
	which will be refined according to Filters,
	Search bar and user name options

Background: 
	Given I visit to Home page
	And I click on Search button
	Then Skills should be successfully displayed

@mytag
Scenario Outline: Filter Skill Results 
	When I click on <Filter> Button
	Then Skill should be refined acording to <Filter> 
Examples: 
	| Filter  |
	| Online  |
	| Onsite  | 
	| ShowAll |

Scenario Outline: Filter Skill Results using Search bar
	When I type <Skill>
	Then Result should be displayed acording to <Skill> 
Examples: 
	| Skill    |
	| Cypress  |
	| Selenium |
	| Cooking  |
	| QA       |

Scenario Outline: Filter Skill Results using both Search bar and Trader name
	Given I type <TraderName> and select the trader
	Then <TraderName>'s skills should be listed 
	When I type <Skill>
	Then Result should be displayed acording to <Skill> 
Examples: 
	| Skill    | TraderName  |
	| Cypress  | pinky singh |
	| Selenium | pinky singh |
