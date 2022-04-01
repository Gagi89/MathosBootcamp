using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPI_list_.Models;
using System.Data.SqlClient;
using TestWebApiService;
using TestWebApiModel;
using System.Threading.Tasks;
using Autofac.Core;
using TestWebApiServiceCommon;
using TestWebApiRepositoryCommon;
using TestWebApiCommon;

namespace TestWebAPI_list_.Controllers

{
    public class BuyerController : ApiController
    {
        private IBuyerService serviceRepository;
        public BuyerController(IBuyerService serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        //GET api/buyer
        [HttpGet, Route("api/buyer")]
        public async Task <HttpResponseMessage> GetBuyerAsync([FromUri]Page page, [FromUri]Sort sort, [FromUri]Filter filter)
        {
            List<BuyerModel> listofbuyers = new List<BuyerModel>();
            listofbuyers = await serviceRepository.GetBuyerAsync(page, sort, filter);
            List<BuyerRest> buyerRests = new List<BuyerRest>();
            foreach (var item in listofbuyers)
            {  
                BuyerRest buyerRest = new BuyerRest();
                buyerRest.Name = item.Name;
                buyerRest.Adress = item.Adress;
                buyerRest.Oib = item.Oib;
                buyerRests.Add(buyerRest);
            }
            if (buyerRests.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "The list of buyers is empty.");
            }
            else return Request.CreateResponse(HttpStatusCode.OK, buyerRests);
        }

        //GET api/buyer/id
        [HttpGet, Route("api/buyer/{id}")]
        public async Task <HttpResponseMessage> GetBuyerByIdAsync(Guid id)
        {

            if (await serviceRepository.BuyerIdCheckAsync(id))
            {
                List<BuyerModel> listofbuyers = new List<BuyerModel>();
                listofbuyers = await serviceRepository.GetBuyerByIdAsync(id);
                List<BuyerRest> buyerRests = new List<BuyerRest>();
                foreach (var item in listofbuyers)
                {
                    BuyerRest buyerRest = new BuyerRest();
                    buyerRest.Name = item.Name;
                    buyerRest.Adress = item.Adress;
                    buyerRest.Oib = item.Oib;
                    buyerRests.Add(buyerRest);
                }
                return Request.CreateResponse(HttpStatusCode.OK, buyerRests);
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer index does not exist.");
        }

        //POST api/buyer
        [HttpPost, Route("api/buyer")]
        public async Task <HttpResponseMessage> PostBuyerAsync(BuyerRest buyer)
        {
            if (buyer.Name == null || buyer.Adress == null || buyer.Oib == 0 || buyer.Name == "" || buyer.Adress == "")
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not all required data was entered.");
            else
            {
                BuyerModel buyerModel = new BuyerModel();
                buyerModel.Name = buyer.Name;
                buyerModel.Adress = buyer.Adress;
                buyerModel.Oib = buyer.Oib;
                await serviceRepository.PostBuyerAsync(buyerModel);
                return Request.CreateResponse(HttpStatusCode.OK, "New buyer inserted.");
            }
        }

        //POST api/buyers
        [HttpPost, Route("api/buyer")]
        public async Task <HttpResponseMessage> PostBuyersAsync(List<BuyerRest> buyer)
        {
            if (buyer == null)
                return Request.CreateResponse(HttpStatusCode.NoContent, "No buyers entered.");
            else
            {
                List<BuyerModel> listofbuyers = new List<BuyerModel>();
                foreach (var item in buyer)
                {
                    BuyerModel buyerModel = new BuyerModel();
                    buyerModel.Name = item.Name;
                    buyerModel.Adress = item.Adress;
                    buyerModel.Oib = item.Oib;
                    listofbuyers.Add(buyerModel);
                }
                await serviceRepository.PostBuyersAsync(listofbuyers);
                return Request.CreateResponse(HttpStatusCode.OK, "New buyers inserted.");
            }
        }

        //PUT api/buyer/id
        [HttpPut, Route("api/buyer/{id}")]
        public async Task <HttpResponseMessage> PutBuyerAsync(Guid id, BuyerRest buyer)
        {
            if (await serviceRepository.BuyerIdCheckAsync(id) == false)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer index does not exist.");
            if (buyer.Name == null || buyer.Adress == null || buyer.Oib == 0 || buyer.Name == "" || buyer.Adress == "")
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not all required data was entered.");
            else
            {
                BuyerModel buyerModel = new BuyerModel();
                buyerModel.Name = buyer.Name;
                buyerModel.Adress = buyer.Adress;
                buyerModel.Oib = buyer.Oib;
                await serviceRepository.PutBuyerAsync(id, buyerModel);
                return Request.CreateResponse(HttpStatusCode.OK, "Buyer has been updated.");
            }
        }

        //DELETE api/buyer/id
        [HttpDelete, Route("api/buyer/{id}")]
        public async Task <HttpResponseMessage> DeleteBuyerAsync(Guid id)
        {
            if (await serviceRepository.BuyerIdCheckAsync(id) == true)
            {
                await serviceRepository.DeleteBuyerAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Buyer has been deleted.");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer index does not exist.");
        }
    }
}
