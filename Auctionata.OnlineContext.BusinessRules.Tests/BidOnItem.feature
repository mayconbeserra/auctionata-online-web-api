Feature: BidOnItem
	In order to bid on an Item
	As a potential buyer
	I want to be able to bid on a Item
	So that I can participate in the auction

@1.0
Scenario: Scenario 1 - displaying information about the current item
	Given I am in the auction room	
	When I see the item
	Then I also see the current item picture, description and name

Scenario: Scenario 2 - single user bidding on an item
	Given I am in the auction room
	When I see the item
	And I place a bid on an Item
	And I am the only bidder
	Then I am the highest bidder

Scenario: Scenario 3 - multiple users bidding on an item - you are first
	Given I am in the auction room
	When I see the item
	And I am the buyer "1" and place on an Item
	And the buyer "2" place on the same Item
	Then The buyer "1" is highest bidder

Scenario: Scenario 4 - multiple users bidding on an item - you are not first
	Given I am in the auction room
	When I see the item
	And the buyer "2" place on the same Item
	And I am the buyer "1" and place on an Item
	And the buyer "3" place on the same Item
	And the buyer "4" place on the same Item
	Then The buyer "2" is highest bidder

