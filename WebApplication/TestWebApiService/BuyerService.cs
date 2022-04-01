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
using TestWebApiRepositoryCommon;
using TestWebApiCommon;

namespace TestWebApiService
{
    public class BuyerService : IBuyerService
    {
        private IBuyerRepository buyerRepository;
        public  BuyerService(IBuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository;
        }

        public async Task <List<BuyerModel>> GetBuyerAsync(Page page, Sort sort, Filter filter)
        {
            return await buyerRepository.GetBuyerAsync(page, sort, filter);
        }

        public async Task <List<BuyerModel>> GetBuyerByIdAsync(Guid id)
        {
            return await buyerRepository.GetBuyerByIdAsync(id);
        }
        public async Task PostBuyerAsync(BuyerModel buyer)
        {
            await buyerRepository.PostBuyerAsync(buyer);
        }
        public async Task PostBuyersAsync(List<BuyerModel> buyer)
        {
            await buyerRepository.PostBuyersAsync(buyer);
        }
        public async Task PutBuyerAsync(Guid id, BuyerModel buyer)
        {
            await buyerRepository.PutBuyerAsync(id, buyer);
        }
        public async Task DeleteBuyerAsync(Guid id)
        {
            await buyerRepository.DeleteBuyerAsync(id);
        }
        public async Task <bool> BuyerIdCheckAsync(Guid id)
        {
            if (await buyerRepository.BuyerIdCheckAsync(id))
                return true;
            else
                return false;
        }
    }
}
