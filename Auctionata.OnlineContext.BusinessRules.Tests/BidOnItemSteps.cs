using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Auctionata.OnlineContext.DomainModel;

namespace Auctionata.OnlineContext.BusinessRules.Tests
{
    [Binding]
    public class BidOnItemSteps
    {
        private Auction auction;

        [Given(@"I am in the auction room")]
        public void GivenIAmInTheAuctionRoom()
        {
            auction = new Auction();
        }
        
        [When(@"I see the item")]
        public void WhenISeeTheItem()
        {
            var item = new Item("New Item", "This is a new Product to be sold", "Path");

            auction.AddItem(item);
        }
        
        [Then(@"I also see the current item picture, description and name")]
        public void ThenIAlsoSeeTheCurrentItemPictureDescriptionAndName()
        {
            Assert.That(!String.IsNullOrEmpty(auction.Item.PicturePath));
            Assert.That(!String.IsNullOrEmpty(auction.Item.Description));
            Assert.That(!String.IsNullOrEmpty(auction.Item.Name));
        }

        [When(@"I place a bid on an Item")]
        public void WhenIPlaceABidOnAnItem()
        {            
            auction.PlaceABid(buyerId: 1);
        }

        [When(@"I am the only bidder")]
        public void WhenIAmTheOnlyBidder()
        {
            Assert.That(auction.Bids.Count == 1);
        }

        [Then(@"I am the highest bidder")]
        public void ThenIAmTheHighestBidder()
        {
            Assert.That(auction.HighestBidder == 1);
        }

        [When(@"I am the buyer ""(.*)"" and place on an Item")]
        public void WhenIAmTheBuyerAndPlaceOnAnItem(int buyerId)
        {
            auction.PlaceABid(buyerId);
        }

        [When(@"the buyer ""(.*)"" place on the same Item")]
        public void WhenTheBuyerPlaceOnTheSameItem(int anotherBuyerId)
        {
            auction.PlaceABid(anotherBuyerId);
        }

        [Then(@"The buyer ""(.*)"" is highest bidder")]
        public void ThenTheBuyerIsHighestBidder(int highestBuyerId)
        {
            Assert.That(auction.HighestBidder == highestBuyerId);
        }
    }
}
