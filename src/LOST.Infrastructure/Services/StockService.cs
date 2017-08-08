using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LOST.Core.Repositories;
using LOST.Infrastructure.Dto;
using System.Linq;

namespace LOST.Infrastructure.Services
{
    public class StockService : IStockService
    {
        private readonly IMaterialDocumentRepository _materialDocumentRepository;
        private readonly ISectorRepository _sectorRepository;
        public StockService(IMaterialDocumentRepository materialDocumentRepository, ISectorRepository sectorRepository)
        {
            _materialDocumentRepository = materialDocumentRepository;
            _sectorRepository = sectorRepository;
        }
        public async Task<IEnumerable<StockDto>> CheckStockAsync(string materialNumber = "", string sectorName = "", string productionOrder = "")
        {
            var sector = await _sectorRepository.GetByNameAsync(sectorName);
            var query = await _materialDocumentRepository.GetByMaterialAsync(materialNumber);

            var result = query
                        .GroupBy(g => new { g.SectorId, g.MaterialNumber, g.ProductionOrder })
                        .Select(x => new StockDto()
                        {
                            SectorName = x.Key.SectorId.ToString(),
                            MaterialNumber = x.Key.MaterialNumber,
                            ProductionOrder = x.Key.ProductionOrder,
                            Quantity = x.Sum(i => i.Quantity)
                        });

            return result;
        }
    }
}