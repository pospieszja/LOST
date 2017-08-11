using System.Collections.Generic;
using System.Threading.Tasks;
using LOST.Infrastructure.Dto;

namespace LOST.Infrastructure.Services
{
    public interface IStockService : IService
    {
        Task<IEnumerable<StockDto>> CheckStockAsync(string materialNumber = "", string sectorName = "", string productionOrder = "");
        Task GoodsReceipt(string materialNumber, int quantity, string sectorName, string productionOrder = "");
        Task GoodsIssue(string materialNumber, int quantity, string sectorName, string productionOrder = "");
    }
}