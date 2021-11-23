Feature: OrderConsultation
	As a user
	I want to see Order button in consultation block
	In order to sign up for chosen consultation
	
@popup
Scenario: Need to authorize before order consultation
	Given Consulting page is open
	When I click Order button in consultations list
	Then Authorize notification opens in pop-up window