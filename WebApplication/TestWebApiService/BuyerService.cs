using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using TestWebApiRepository;
using TestWebApiModel;
using TestWebApiServiceCommon;

namespace TestWebApiService
{
    public class BuyerService : IServiceRepository
    {
        public async Task <List<BuyerModel>> GetBuyerAsync()
        {
            BuyerRepository buyerRepository = new BuyerRepository();
            return await buyerRepository.GetBuyerAsync();
        }

        public async Task <List<BuyerModel>> GetBuyerByIdAsync(Guid id)
        {
            BuyerRepository buyerRepository = new BuyerRepository();
            return await buyerRepository.GetBuyerByIdAsync(id);
        }
        public async Task PostBuyerAsync(BuyerModel buyer)
        {
            BuyerRepository buyerRepository = new BuyerRepository();
            await buyerRepository.PostBuyerAsync(buyer);
        }
        public async Task PostBuyersAsync(List<BuyerModel> buyer)
        {
            BuyerRepository buyerRepository = new BuyerRepository();
            await buyerRepository.PostBuyersAsync(buyer);
        }
        public async Task PutBuyerAsync(Guid id, BuyerModel buyer)
        {
            BuyerRepository buyerRepository = new BuyerRepository();
            await buyerRepository.PutBuyerAsync(id, buyer);
        }
        public async Task DeleteBuyerAsync(Guid id)
        {
            BuyerRepository buyerRepository = new BuyerRepository();
            await buyerRepository.DeleteBuyerAsync(id);
        }
        public async Task <bool> BuyerIdCheckAsync(Guid id)
        {
            BuyerRepository buyerRepository = new BuyerRepository();
            if (await buyerRepository.BuyerIdCheckAsync(id) == true)
                return true;
            else
                return false;
        }
    }
}
