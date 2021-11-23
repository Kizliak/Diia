Feature: DropDownMenu
	As a user
	I want to see subcategories menu
	In order to navigate faster

@mytag
Scenario: Click item in dropdown menu
	Given Business page is open
	When I move mouse to menu element
	Then Dropdown menu display category links
	When I click on link frop dropdown menu
	Then I get to corresponding page