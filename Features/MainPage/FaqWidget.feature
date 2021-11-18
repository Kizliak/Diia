Feature: FaqWidget
	As a user
	I want to see popular questions on homepage
	In order to get links to related answers

Background: 
	Given Main page is open

Scenario: Open answer page
	When I scroll to questions widget
	When I click on first question in block
	Then Page with related answer is open