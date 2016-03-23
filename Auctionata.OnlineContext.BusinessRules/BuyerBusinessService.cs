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
    public class BuyerBusinessService : IBuyerBusinessService
    {
        private readonly IBuyerRepository repository;

        public BuyerBusinessService(IBuyerRepository repository)
        {
            this.repository = repository;
        }

        IEnumerable<Buyer> IBuyerBusinessService.GetAll()
        {
            return repository.GetAll();
        }

        Buyer IBuyerBusinessService.GetById(int buyerId)
        {
            return repository.GetById(buyerId);
        }
    }
}
