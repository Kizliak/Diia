Feature: Accordion
	As a user
	I want to click accordion items
	In order to read answer for my question

Background: 
	Given Consulting page is open

@accordion
Scenario: Click on accordion item
	When I click on question from accordion list
	Then Text block with answer to question open