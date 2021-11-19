Feature: NewsFeature
	As a user
	I want to see more news on news page
	In order to get access faster

Background: 
	Given News page is open

Scenario: Check the more news button
	When I scroll to more news button
	When I click on more news button
	Then Сount with news blocks in the page is 12
	Then I see second page number navigation


Scenario: Check the news title link move to page about this news info
    When I click on the title in first news block
	Then I see text of the news first title

Scenario: Check the news page number navigation
    When I scroll to page number navigation
	When I click on the second page number
	Then I see first block text on the second page 
	Then I see whitch second selector navigation


