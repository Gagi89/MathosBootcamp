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

namespace TestWebAPI_list_.Controllers

{
    public class BuyerController : ApiController
    {
        //GET api/buyer
        [HttpGet, Route("api/buyer")]
        public async Task <HttpResponseMessage> GetBuyerAsync()
        {
            BuyerService buyerService = new BuyerService();
            List<BuyerModel> listofbuyers = new List<BuyerModel>();
            listofbuyers = await buyerService.GetBuyerAsync();
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
            BuyerService buyerService = new BuyerService();

            if (await buyerService.BuyerIdCheckAsync(id) == true)
            {
                List<BuyerModel> listofbuyers = new List<BuyerModel>();
                listofbuyers = await buyerService.GetBuyerByIdAsync(id);
                List<BuyerRest> buyerRests = new List<BuyerRest>();
                foreach (var item in listofbuyers)
                {
                    BuyerRest buyerRest = new BuyerRest();
                    buyerRest.Name = item.Name;
                    buyerRest.Adress = item.Adress;
                    buyerRest.Oib = item.Oib;
                    buyerRests.Add(buyerRest);
                }
                if (buyerRests != null)
                    return Request.CreateResponse(HttpStatusCode.OK, buyerRests);
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer index does not exist.");
        }

        //POST api/buyer
        [HttpPost, Route("api/buyer")]
        public async Task <HttpResponseMessage> PostBuyerAsync(BuyerRest buyer)
        {
            if (buyer.Name == null || buyer.Adress == null || buyer.Oib == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not all required data was entered.");
            else
            {
                BuyerModel buyerModel = new BuyerModel();
                buyerModel.Name = buyer.Name;
                buyerModel.Adress = buyer.Adress;
                buyerModel.Oib = buyer.Oib;
                BuyerService buyerService = new BuyerService();
                await buyerService.PostBuyerAsync(buyerModel);
                return Request.CreateResponse(HttpStatusCode.OK, "New buyer inserted.");
            }
        }

        //POST api/buyers
        [HttpPost, Route("api/buyers")]
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
                BuyerService buyerService = new BuyerService();
                await buyerService.PostBuyersAsync(listofbuyers);
                return Request.CreateResponse(HttpStatusCode.OK, "New buyers inserted.");
            }
        }

        //PUT api/buyer/id
        [HttpPut, Route("api/buyer/{id}")]
        public async Task <HttpResponseMessage> PutBuyerAsync(Guid id, BuyerRest buyer)
        {
            BuyerService buyerService = new BuyerService();
            if (await buyerService.BuyerIdCheckAsync(id) == true && buyer != null)
            {
                BuyerModel buyerModel = new BuyerModel();
                buyerModel.Name = buyer.Name;
                buyerModel.Adress = buyer.Adress;
                buyerModel.Oib = buyer.Oib;
                await buyerService.PutBuyerAsync(id, buyerModel);
                return Request.CreateResponse(HttpStatusCode.OK, "Buyer has been updated.");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer index does not exist.");
        }

        //DELETE api/buyer/id
        [HttpDelete, Route("api/buyer/{id}")]
        public async Task <HttpResponseMessage> DeleteBuyerAsync(Guid id)
        {
            BuyerService buyerService = new BuyerService();
            if (await buyerService.BuyerIdCheckAsync(id) == true)
            {
                await buyerService.DeleteBuyerAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Buyer has been deleted.");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer index does not exist.");
        }
    }

    public class BuyerRest
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public long Oib { get; set; }
    }
}
