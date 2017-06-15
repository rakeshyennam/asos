Feature: Use the webiste to change the price display in NewZealand dollars when I am in Australian store

Scenario: Dispaly prices in NewZealand dollars when I am in Australian store
	Given I am on australian site
	When I select the display price option as New Zeeland dollar
	Then I should see all the items display price in NewZealand dollars 