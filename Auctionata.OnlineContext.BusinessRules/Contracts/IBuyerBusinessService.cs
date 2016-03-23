using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auctionata.OnlineContext.DomainModel;

namespace Auctionata.OnlineContext.BusinessRules.Contracts
{
    public interface IBuyerBusinessService
    {
        Buyer GetById(int buyerId);
        IEnumerable<Buyer> GetAll();
    }
}
