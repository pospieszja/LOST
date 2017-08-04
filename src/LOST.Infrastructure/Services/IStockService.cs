using System.Collections.Generic;
using System.Threading.Tasks;
using LOST.Infrastructure.Dto;

namespace LOST.Infrastructure.Services
{
    public interface IStockService : IService
    {
        Task<IEnumerable<StockDto>> CheckStockAsync(string materialNumber = "", string sectorName = "", string productionOrder = "");
    }
}