Feature: BidOnItem
	In order to bid on an Item
	As a potential buyer
	I want to be able to bid on a Item
	So that I can participate in the auction

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

Scenario: Scenario 5 - Place a bid on an item only if my bid is higher than the old one
	Given I am in the auction room
	When I see the item
	And the buyer "2" place "100" as a bid on the same Item
	And I am the buyer "1" and place "50" on the same Item
	Then my bid is not added

Scenario: Scenario 6 - Place a highest bid on an item
	Given I am in the auction room
	When I see the item
	And the buyer "1" place "50" as a bid on the same Item
	And the buyer "2" place "100" as a bid on the same Item
	Then The buyer "2" is highest bidder

Scenario: Scenario 7 - Place a bid on an item that there is an initial price very high - my bid is not added
	Given I am in the auction room
	When I see the item with the initial price as "25"
	And I am the buyer "1" and place "10" on the same Item
	And the buyer "2" place "50" as a bid on the same Item
	Then my bid is not added

