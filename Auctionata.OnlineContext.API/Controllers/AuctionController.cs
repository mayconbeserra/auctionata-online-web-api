using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Auctionata.OnlineContext.BusinessRules.Contracts;
using Auctionata.OnlineContext.DomainModel;

namespace Auctionata.OnlineContext.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("auctionata/api/v1/auctions")]
    public class AuctionController : ApiController
    {
        private readonly IAuctionBusinessService auctionBusinessService;

        public AuctionController(IAuctionBusinessService service)
        {
            auctionBusinessService = service;
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> GetAllAuctions()
        {
            HttpResponseMessage response;

            try
            {
                var result = auctionBusinessService.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var taskCompletion = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletion.SetResult(response);

            return taskCompletion.Task;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<HttpResponseMessage> GetAuctionById(int auctionId)
        {
            HttpResponseMessage response;

            try
            {
                var result = auctionBusinessService.GetById(auctionId);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var taskCompletion = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletion.SetResult(response);

            return taskCompletion.Task;
        }

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> PostAuction(Auction entity)
        {
            HttpResponseMessage response;

            try
            {
                auctionBusinessService.Save(entity);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var taskCompletion = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletion.SetResult(response);

            return taskCompletion.Task;
        }

        [HttpPost]
        [Route("bid/{auctionId}/{buyerId}/{bidValue?}")]
        public Task<HttpResponseMessage> Bid(int auctionId, int buyerId, double bidValue)
        {            
            HttpResponseMessage response;

            try
            {
                var result = auctionBusinessService.PlaceBid(auctionId, buyerId, bidValue);

                if (result != null)
                    response = Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Place a bid was not possible for this auction.");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var taskCompletion = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletion.SetResult(response);

            return taskCompletion.Task;
        }
    }
}
