Feature: NewsFeature
	As a user
	I want to see more news on news page
	In order to get access faster

Background: 
	Given News page is open

	@newsPage
Scenario: Check the more news button
	When I click on more news button on the first page
	Then Сount with news blocks in the page is 12
	Then I see second page number navigation

	@newsPage
Scenario: Check the news title link move to page about this news info
    When I click on the title in first news block
	Then I see text of the news first title

	@newsPage
Scenario: Check the news page number navigation
	When I click on the second page number
	Then I see first block text on the second page 
	Then I see switch second selector navigation

	@newsPage
Scenario: Check navigation to the previous page by click on the 'Previous page' button
    When I click the next page button
	Then I go to the next page
	When I click the previous page button
	Then I go to the previous page


