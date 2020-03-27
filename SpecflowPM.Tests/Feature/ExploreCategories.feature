Feature: ExploreCategories
	Feature related to Search Skills according to Categories and Subcategories

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
	When I click on <CategoryName> and <SubCategoryName>
	Then I should successfully view service per <CategoryName>, <CategoryIndex> and <SubCategoryIndex>
Examples: 
	| CategoryName        | CategoryIndex | SubCategoryName             | SubCategoryIndex |
	| Graphics Design     | 1             | Logo Design                 | 1                |
	| Graphics Design     | 1             | Book & Album covers         | 2                |
	| Graphics Design     | 1             | Flyers & Brochures          | 3                |
	| Graphics Design     | 1             | Web & Mobile Design         | 4                |
	| Graphics Design     | 1             | Search & Display Marketing  | 5                |
	| Digital Marketing   | 2             | Social Media Marketing      | 1                |
	| Digital Marketing   | 2             | Content Marketing           | 2                |
	| Digital Marketing   | 2             | Video Marketing             | 3                |
	| Digital Marketing   | 2             | Email Marketing             | 4                |
	| Digital Marketing   | 2             | Search & Display Marketing  | 5                |
	| Writing Translation | 3             | Resumes & Cover Letters     | 1                |
	| Writing Translation | 3             | Proof Reading & Editing     | 2                |
	| Writing Translation | 3             | Translation                 | 3                |
	| Writing Translation | 3             | Creative Writing            | 4                |
	| Writing Translation | 3             | Business Copywriting        | 5                |
	| Video Animation     | 4             | Promotional Videos          | 1                |
	| Video Animation     | 4             | Editing & Post Production   | 2                |
	| Video Animation     | 4             | Lyric & Music Videos        | 3                |
	| Video Animation     | 4             | Other                       | 4                |
	| Music Audio         | 5             | Mixing & Mastering          | 1                |
	| Music Audio         | 5             | Voice Over                  | 2                |
	| Music Audio         | 5             | Song Writers & Composers    | 3                |
	| Music Audio         | 5             | Other                       | 4                |
	| Programming Tech    | 6             | WordPress                   | 1                |
	| Programming Tech    | 6             | Web & Mobile App            | 2                |
	| Programming Tech    | 6             | Data Analysis & Reports     | 3                |
	| Programming Tech    | 6             | QA                          | 4                |
	| Programming Tech    | 6             | Databases                   | 5                |
	| Programming Tech    | 6             | Other                       | 6                |
	| Business            | 7             | Business Tips               | 1                |
	| Business            | 7             | Presentations               | 2                |
	| Business            | 7             | Market Advice               | 3                |
	| Business            | 7             | Legal Consulting            | 4                |
	| Business            | 7             | Financial Consulting        | 5                |
	| Business            | 7             | Other                       | 6                |
	| Fun Lifestyle       | 8             | Online Lessons              | 1                |
	| Fun Lifestyle       | 8             | Relationship Advice         | 2                |
	| Fun Lifestyle       | 8             | Astrology                   | 3                |
	| Fun Lifestyle       | 8             | Health, Nutrition & Fitness | 4                |
	| Fun Lifestyle       | 8             | Gaming                      | 5                |
	| Fun Lifestyle       | 8             | Other                       | 6                |

	

#Examples: 
#	| subcat1                  |
#	| Logo Design              |
#	| Book Album covers        |
#	| Flyers Brochures16       |
#	| Web Mobile Design        |
#	| Search Display Marketing |
#Examples: 
#	| subcat2                  |
#	| Social Media Marketing   |
#	| Content Marketing        |
#	| Video Marketing          |
#	| Email Marketing          |
#	| Search Display Marketing |
#Examples: 
#	| subcat3               |
#	| Resumes Cover Letters |
#	| Proof Reading Editing |
#	| Translation           |
#	| Creative Writing      |
#	| Business Copywriting  |
#Examples: 
#	| subcat4                 |
#	| Promotional Videos      |
#	| Editing Post Production |
#	| Lyric Music Videos      |
#	| Other                   |                   
#Examples: 	
#	| subcat5                |
#	| Mixing Mastering       |
#	| Voice Over             |
#	| Song Writers Composers |
#	| Other                  |
#Examples: 
#	| subcat6               |
#	| WordPress             |
#	| Web Mobile App        |
#	| Data Analysis Reports |
#	| QA                    |
#	| Databases             |
#	| Other                 |
#Examples: 
#	| subcat7              |
#	| Business Tips        |
#	| Presentations        |
#	| Market Advice        |
#	| Legal Consulting     |
#	| Financial Consulting |
#	| Other                |
#Examples: 
#	| subcat8                   |
#	| Online Lessons            |
#	| Relationship Advice       |
#	| Astrology                 |
#	| Health Nutrition  Fitness |
#	| Gaming                    |
#	| Other                     |








