namespace Auctionata.OnlineContext.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionBids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuctionId = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        BidValue = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .Index(t => t.AuctionId)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        PicturePath = c.String(),
                        InitialPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionBids", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Auctions", "ItemId", "dbo.Items");
            DropForeignKey("dbo.AuctionBids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Auctions", new[] { "ItemId" });
            DropIndex("dbo.AuctionBids", new[] { "BuyerId" });
            DropIndex("dbo.AuctionBids", new[] { "AuctionId" });
            DropTable("dbo.Buyers");
            DropTable("dbo.Items");
            DropTable("dbo.Auctions");
            DropTable("dbo.AuctionBids");
        }
    }
}
