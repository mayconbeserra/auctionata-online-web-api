using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auctionata.OnlineContext.BusinessRules.Contracts;
using Auctionata.OnlineContext.DomainModel;
using Auctionata.OnlineContext.DomainModel.Repositories;

namespace Auctionata.OnlineContext.BusinessRules
{
    public class AuctionBusinessService : IAuctionBusinessService
    {
        private readonly IAuctionRepository repository;
        private readonly IBuyerRepository buyerRepository;

        public AuctionBusinessService(IAuctionRepository repository, IBuyerRepository buyerRepository)
        {
            this.repository = repository;
            this.buyerRepository = buyerRepository;
        }

        void IAuctionBusinessService.Save(Auction auction)
        {
            Auction auctionPersistent = auction.Id == 0 ? auction : this.repository.GetById(auction.Id);

            if (auction.Id == 0)
            {
                this.repository.Create(auction);
            }
            else
            {
                this.repository.Update(auction);
            }
        }
        Auction IAuctionBusinessService.PlaceBid(int auctionId, int buyerId, double value)
        {
            Auction auction = this.repository.GetById(auctionId);
            Buyer buyer = this.buyerRepository.GetById(buyerId);

            if (buyer == null)
                return null;

            if (auction == null)
                return null;

            if (!auction.PlaceABid(buyerId, value))
                return null;

            this.repository.Update(auction);

            auction.Bids.Last().Buyer = buyer;

            return auction;
        }
        Auction IAuctionBusinessService.GetById(int auctionId)
        {
            return this.repository.GetById(auctionId);
        }
        IEnumerable<Auction> IAuctionBusinessService.GetAll()
        {
            return this.repository.GetAll();
        }
    }
}
