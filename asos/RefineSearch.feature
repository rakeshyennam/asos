Feature: Use website to refine search to display items for men
so that I can only find items for men 

Scenario Outline: Dispaly items based on refined search
	Given I am on asos search results page
	When I refined search to display only items for <gender>
	Then I can find only items for refined search 

Examples: 
| gender |
| Men    |
| Women  |	

