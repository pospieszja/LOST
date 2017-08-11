using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LOST.Core.Repositories;
using LOST.Infrastructure.Dto;
using System.Linq;
using LOST.Core.Domain;

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
            var query = await _materialDocumentRepository.BrowseAsync(materialNumber,"",productionOrder);

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

        public async Task GoodsIssue(string materialNumber, int quantity, string sectorName, string productionOrder = "")
        {
            var sector = await _sectorRepository.GetByNameAsync(sectorName);

            var materialDocument = new MaterialDocument(Guid.NewGuid(),materialNumber, quantity, sector.Id, productionOrder);
            await _materialDocumentRepository.AddAsync(materialDocument);
        }

        public async Task GoodsReceipt(string materialNumber, int quantity, string sectorName, string productionOrder = "")
        {
            var sector = await _sectorRepository.GetByNameAsync(sectorName);
            
            var materialDocument = new MaterialDocument(Guid.NewGuid(),materialNumber, quantity, sector.Id, productionOrder);
            await _materialDocumentRepository.AddAsync(materialDocument);
        }
    }
}