Feature: PopularServices
	As a user
	I want to see popular services on the main page
	In order to get access faster

Background: 
	Given Main page is open

@Click
Scenario: Check navigation to service page from the block of popular services 
	When I click on the first service
	Then I navigate to the service page

Scenario: Check the swipe right of the swiper with popular services using right button
	When I click on the swiper right button
	Then Popular services moved right on one position

Scenario: Check the swipe left of the swiper with popular services using left button
	When I click on the swiper right button
	Then Popular services moved right on one position
	When I click on the swiper left button
	Then Popular services moved left on one position