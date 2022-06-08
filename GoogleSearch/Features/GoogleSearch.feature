Feature: GoogleSearch
Scenario: Search specflow in google search bar
	Given I navigate to the google search page
	And I enter specflow in the search field
	When I press enter key
	Then the result should be displayed for specflow
	And I clicked the third result