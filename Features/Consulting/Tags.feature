Feature: CategoryTags
	As a user
	I want to see cloud of category tags
	In order to get fast access to connected pages

Scenario Outline: Click on tag opens corresponding page
	Given Consulting page is open
	When I click on tag <categoryTag>
	Then I get to page <categoryPage> corresponding to this tag

Examples: 
	| categoryTag                    | categoryPage                  |
	| Знайомство                     | consulting/znajomstvo         |
	| Систематизація бізнес-процесів | consulting/business-processes |
	| Фінанси                        | consulting/finances           |
	| Юридична підтримка             | consulting/legal-support      |
	| Маркетинг                      | consulting/marketing          |
	| Продажі                        | consulting/sales              |
	| Масштабування                  | consulting/scale              |
	| HR                             | consulting/hr                 |