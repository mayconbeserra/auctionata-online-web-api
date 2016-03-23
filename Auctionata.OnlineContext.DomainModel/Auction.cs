using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctionata.OnlineContext.DomainModel
{
    public class Auction
    {
        #region Constructors
        public Auction()
        {
            Bids = new List<AuctionBid>();
        }
        public Auction(int id, Item item) : this()
        {
            this.Id = id;
            this.Item = item;
        }

        #endregion

        #region Properties
        public int Id { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; protected set; }
        public double HighestBid
        {
            get
            {
                if (this.Item == null || this.Bids.Count == 0)
                {
                    return 0;
                }

                return this.Bids
                            .OrderByDescending(x => x.BidValue)
                            .FirstOrDefault()
                            .BidValue;
            }
        }
        public int HighestBidder
        {
            get
            {
                if (this.Bids.Count == 0)
                    return 0;

                return this.Bids
                    .OrderBy(bid => bid.CreatedAt)
                    .OrderByDescending(bids => bids.BidValue)
                    .ElementAt(0)
                    .BuyerId;
            }
        }

        public string HighestBidderName
        {
            get
            {
                if (this.Bids.Count == 0)
                    return String.Empty;

                return this.Bids
                    .OrderBy(bid => bid.CreatedAt)
                    .OrderByDescending(bids => bids.BidValue)
                    .ElementAt(0)
                    .Buyer.Name;
            }
        }
        public virtual IList<AuctionBid> Bids { get; protected set; }
        #endregion

        #region Methods
        public void AddItem(Item item)
        {
            Item = item;
        }

        public bool PlaceABid(int buyerId, double bidValue)
        {
            if (this.Item.InitialPrice >= bidValue)
                return false;

            if (Bids.Any(x => x.BidValue >= bidValue))
                return false;

            Bids.Add(new AuctionBid(this.Id, buyerId, bidValue));

            return true;
        }

        #endregion
    }
}
