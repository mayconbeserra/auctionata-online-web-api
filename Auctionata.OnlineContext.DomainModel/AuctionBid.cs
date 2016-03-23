using System;

namespace Auctionata.OnlineContext.DomainModel
{
    public class AuctionBid
    {
        #region Constructors

        protected AuctionBid()
        {

        }
        public AuctionBid(int auctionId, int buyerId, double bidValue)
        {
            this.AuctionId = auctionId;
            this.BuyerId = buyerId;
            this.BidValue = bidValue;
            this.CreatedAt = DateTime.Now;
        }

        #endregion

        #region Properties

        public int Id { get; protected set; }
        public int AuctionId { get; protected set; }
        public int BuyerId { get; protected set; }
        public double BidValue { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public virtual Auction Auction { get; set; }
        public virtual Buyer Buyer { get; set; }

        #endregion
    }
}