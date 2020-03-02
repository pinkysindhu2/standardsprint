Feature: ExploreCategories
	Feature related to Seach Skills according to Categories and Subcategories

#Scenario Outline: Search skills per category
#	Given I visit to Home page
#	And I scroll down to Explore category
#	When I click on Category
#	| CategoryName          | CategoryIndex |
#	| Graphic Design        | 1             |
#	| Digital Marketing     | 2             |
#	| Writing  Translation	| 3             |
#	| Video  Animation		| 4             |
#	| Music Audio           | 5             |
#	| Programming Tech      | 6             |
#	| Business              | 7             |
#	| Fun  Lifestyle		| 8             |
#	Then I should successfully view service per category

Scenario Outline: Search skills per category
	Given I visit to Home page
	And I scroll down to Explore category
	When I click on Category <CategoryName>
	Then I should successfully view service per <CategoryName> and <CategoryIndex>
Examples: 
	| CategoryName          | CategoryIndex |
	| Graphics Design       | 1             |
	| Digital Marketing     | 2             |
	| Writing Translation	| 3             |
	| Video Animation		| 4             |
	| Music Audio           | 5             |
	| Programming Tech      | 6             |
	| Business              | 7             |
	| Fun Lifestyle         | 8             |