using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApiModel;

namespace TestWebApiServiceCommon
{
    public interface IServiceRepository
    {
        Task <List<BuyerModel>> GetBuyerAsync();
        Task <List<BuyerModel>> GetBuyerByIdAsync(Guid id);
        Task PostBuyerAsync(BuyerModel buyer);
        Task PostBuyersAsync(List<BuyerModel> buyer);
        Task PutBuyerAsync(Guid id, BuyerModel buyer);
        Task DeleteBuyerAsync(Guid id);
        Task<bool> BuyerIdCheckAsync(Guid id);
    }
}
