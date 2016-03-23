using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auctionata.OnlineContext.DomainModel;

namespace Auctionata.OnlineContext.Data
{
    public class AuctionataDbContext : DbContext
    {
        public AuctionataDbContext() : base("AuctionataDbContext")
        {
            Database.SetInitializer<AuctionataDbContext>(null);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }
    }
}
