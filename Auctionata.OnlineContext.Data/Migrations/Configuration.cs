namespace Auctionata.OnlineContext.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Auctionata.OnlineContext.Data.AuctionataDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Auctionata.OnlineContext.Data.AuctionataDbContext context)
        {
            context.Buyers.AddOrUpdate(new DomainModel.Buyer("Martin Pernecky"));
            context.Buyers.AddOrUpdate(new DomainModel.Buyer("Maycon Beserra"));

            context.Items.AddOrUpdate
            (
                new DomainModel.Item
                (
                    "Bracelet",
                    "Bracelet, 14K Gold, Enamel, Sapphire & Diamonds, USA, c. 1965",
                    "https://d2c2dsgt13elzw.cloudfront.net/resources/1000x1000/c6/fc/8b3e-ca98-4bda-8ef4-1028ae5a73ba.jpg",
                    100
                ),
                new DomainModel.Item
                (
                    "Navajo Necklace",
                    "Navajo Necklace, Turquoise and Sterling Silver, USA, c. 1970",
                    "https://d2c2dsgt13elzw.cloudfront.net/resources/1000x1000/19/8d/be5a-85ec-4ba7-ab04-1301d1ab4c5d.jpg",
                    150
                ),
                new DomainModel.Item
                (
                    "Earrings",
                    "Earrings, 18K Yellow Gold and Lapis, Italy, c. 1980",
                    "https://d2c2dsgt13elzw.cloudfront.net/resources/1000x1000/e3/2f/29fb-7a7d-4691-9de0-fcb7f490486e.jpg",
                    300
                )
            );
        }
    }
}
