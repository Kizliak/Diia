@MainPage @Search
Feature: Search
	As a user
	I want to search information on the main page
	In order to navigate faster

Background: 
	Given Main page is open

@valid
Scenario: Сheck the search results with valid input
	When I input 'відкрити ФОП' in the search field
	When I click on the search button
	Then l see a search page with text'За вашим запитом знайдено матеріалів:'

@invalidCheckSearch
Scenario: Сheck the search with no result
	When I input 'rgfalerhbfg' in the search field
	When I click on the search button
	Then l see a search page with text'За вашим запитом не знайдено матеріалів:'