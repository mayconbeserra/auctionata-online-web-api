using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auctionata.OnlineContext.DomainModel;
using Auctionata.OnlineContext.DomainModel.Repositories;

namespace Auctionata.OnlineContext.Data.Repositories
{
    public class BuyerRepository : RepositoryBase<Buyer>, IBuyerRepository
    {
        public BuyerRepository(AuctionataDbContext context): base(context)
        {
        }
    }
}