Feature: ShowMore
	As a user
	I want to click Show More button
	In order to see more consultation offers on page

@mytag
Scenario: Click Show More button
	Given Consulting page is open
	When I click Show more button
	Then I see 12 consultation blocks on page