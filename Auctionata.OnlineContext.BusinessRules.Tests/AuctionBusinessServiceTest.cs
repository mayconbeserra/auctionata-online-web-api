using System.Collections.Generic;
using System.Linq;
using Auctionata.OnlineContext.BusinessRules.Contracts;
using Auctionata.OnlineContext.DomainModel;
using Auctionata.OnlineContext.DomainModel.Repositories;
using Moq;
using NUnit.Framework;

namespace Auctionata.OnlineContext.BusinessRules.Tests
{
    [TestFixture]
    public class AuctionBusinessServiceTest
    {
        private Mock<IAuctionRepository> mockRepository;
        private Mock<IBuyerRepository> mockBuyerRepository;
        private IAuctionBusinessService auctionService;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IAuctionRepository>();
            mockBuyerRepository = new Mock<IBuyerRepository>();

            auctionService = new AuctionBusinessService(mockRepository.Object, mockBuyerRepository.Object);

            mockBuyerRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Buyer(2, It.IsAny<string>()));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void When_Saving_An_Auction_Then_TheRepository_Should_Be_Called(bool newAuction)
        {
            var auction = newAuction ? new Auction() : new Auction(1, It.IsAny<Item>());

            mockRepository.Setup(x => x.Create(auction)).Verifiable();
            mockRepository.Setup(x => x.Update(auction)).Verifiable();

            auctionService.Save(auction);

            if (newAuction)
            {
                mockRepository.Verify(x => x.Create(It.IsAny<Auction>()), Times.Once);
                mockRepository.Verify(x => x.Update(It.IsAny<Auction>()), Times.Never);
            } else
            {
                mockRepository.Verify(x => x.Create(It.IsAny<Auction>()), Times.Never);
                mockRepository.Verify(x => x.Update(It.IsAny<Auction>()), Times.Once);
            }
        }

        [Test]
        public void When_Place_A_Bid_Then_TheAuctionBid_Should_Be_Added_For_TheBuyer()
        {
            //Arrange
            var auction = new Auction
                (
                    It.IsAny<int>(), 
                    new Item(
                        It.IsAny<string>(), 
                        It.IsAny<string>(), 
                        It.IsAny<string>(), 50)
                );
            mockRepository.Setup(x => x.GetById(1)).Returns(auction);

            //Act
            auctionService.PlaceBid(1, 2, 100);

            //Assert
            mockRepository.Verify(x => x.Update(auction), Times.Once);

            Assert.That(auction.Bids.Count == 1);
            Assert.That(auction.Bids.FirstOrDefault().BuyerId == 2);
        }

        [Test]
        public void When_PlaceABid_For_A_Non_Existing_Auction_Then_Returns_Null()
        {
            //Arrange
            mockRepository.Setup(x => x.GetById(1));

            //Act
            var result = auctionService.PlaceBid(1, 2, 100);

            //Assert
            mockRepository.Verify(x => x.Update(It.IsAny<Auction>()), Times.Never);

            Assert.That(result == null);
        }

        [Test]
        public void When_GetAllAuctions_Then_Returns_All_TheAuctions()
        {
            //Arrange
            IList<Auction> listOfAuctions = new List<Auction>();

            listOfAuctions.Add(new Auction());
            listOfAuctions.Add(new Auction());
            listOfAuctions.Add(new Auction());

            mockRepository.Setup(x => x.GetAll()).Returns(listOfAuctions);

            //Act And Assert
            Assert.That(auctionService.GetAll().Count() == 3);
        }

        [Test]
        public void When_GetAuctionById_Then_Get_TheAuction_By_Id()
        {
            //Arrange
            var newAuction = new Auction();

            mockRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(newAuction);

            //Act and Assert
            Assert.That(auctionService.GetById(It.IsAny<int>()) == newAuction);
        }
    }
}
