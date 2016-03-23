using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Auctionata.OnlineContext.BusinessRules.Contracts;

namespace Auctionata.OnlineContext.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("auctionata/api/v1/buyers")]
    public class BuyerController : ApiController
    {
        private readonly IBuyerBusinessService buyerBusinessService;

        public BuyerController(IBuyerBusinessService service)
        {
            buyerBusinessService = service;
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> GetAllBuyers()
        {
            HttpResponseMessage response;

            try
            {
                var result = buyerBusinessService.GetAll();
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
        public Task<HttpResponseMessage> GetBuyerById(int id)
        {
            HttpResponseMessage response;

            try
            {
                var result = buyerBusinessService.GetById(id);

                if (result != null)
                    response = Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    response = Request.CreateResponse(HttpStatusCode.NotFound);
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