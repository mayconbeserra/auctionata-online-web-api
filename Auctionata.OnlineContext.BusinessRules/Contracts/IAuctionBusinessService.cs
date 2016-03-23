using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auctionata.OnlineContext.DomainModel;

namespace Auctionata.OnlineContext.BusinessRules.Contracts
{
    public interface IAuctionBusinessService
    {
        void Save(Auction auction);
        Auction PlaceBid(int auctionId, int buyerId, double value);
        Auction GetById(int auctionId);
        IEnumerable<Auction> GetAll();        
    }
}
