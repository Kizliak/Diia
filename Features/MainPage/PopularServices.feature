Feature: PopularServices
	As a user
	I want to see popular services on the main page
	In order to get access faster

Background: 
	Given Main Page is open

@Click
Scenario: Check navigation to service page from the block of popular services 
	When I click on the first service
	Then I navigate to the service page


@swiper @Popularservice
Scenario: Check the swipe right the popular services by swiper-right button
	When I click on the swiper rigt button
	Then Popular servises moved right on one position

@swiper @Popularservice
Scenario: Check the swipe left the popular services by swiper-left button
	When I click on the swiper rigt button
	Then Popular servises moved right on one position
	When I click on the swiper left button
	Then Popular servises moved left on one position

@swiper @Popularservice
Scenario: Check the swipe to the left of popular services by left-bullet pagination
	When I click on the right side of the pagination bullet bar
	Then Popular services moved right on one position.
	When I click on the left side of the pagination bullet bar
	Then Popular services moved left on one position.

@swiper @Popularservice
Scenario: Check the swipe to the right of popular services by right-bullet pagination
	When I click on the right side of the pagination bullet bar
	Then Popular services moved right on one position.