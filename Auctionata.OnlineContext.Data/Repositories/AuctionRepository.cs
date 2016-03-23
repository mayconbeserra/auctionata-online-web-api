using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Auctionata.OnlineContext.DomainModel;
using Auctionata.OnlineContext.DomainModel.Repositories;

namespace Auctionata.OnlineContext.Data.Repositories
{
    public class AuctionRepository : RepositoryBase<Auction>, IAuctionRepository
    {
        public AuctionRepository(AuctionataDbContext context): base(context)
        {
        }

        public override IEnumerable<Auction> GetAll()
        {
            return this.context.Auctions
                                .Include(x => x.Item)
                                .Include(x => x.Bids.Select(y => y.Buyer))
                                .ToList();
        }

        public override Auction GetById(int id)
        {
            return this.context.Auctions
                                .Include(x => x.Item)
                                .Include(x => x.Bids.Select(y => y.Buyer))
                                .Where(x => x.Id == id)
                                .FirstOrDefault();
        }
    }
}
