@MainPage @Search
Feature: Search
	As a user
	I want to search information on the main page
	In order to navigate faster

Background: 
	Given Main page is open

@Valid
Scenario: Check the search results with valid input
#Scenario: Test to get search result output if valid text submited
	When I input 'відкрити ФОП' in the search field
	When I click submit button 
	Then I see search result page that contains text 'За вашим запитом знайдено матеріалів'

@Invalid
Scenario: Check the search with no result
	When I input 'dfdsfdsfdf' in the search field
	When I click submit button
	Then I see search result page that contains text 'За вашим запитом не знайдено матеріалів'