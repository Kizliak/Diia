Feature: Accordion
	FAQ as a list of accordion items

Background: 
	Given Consulting page is open

@accordion
Scenario: Click on accordion item
	When I click on question from accordion list
	Then Text block with answer to question open