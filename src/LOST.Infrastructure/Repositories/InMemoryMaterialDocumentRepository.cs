using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOST.Core.Domain;
using LOST.Core.Repositories;

namespace LOST.Infrastructure.Repositories
{
    public class InMemoryMaterialDocumentRepository : IMaterialDocumentRepository
    {
        private readonly ISet<MaterialDocument> _materialDocuments = new HashSet<MaterialDocument>();

        public InMemoryMaterialDocumentRepository()
        {
            var guid = Guid.NewGuid();
            _materialDocuments.Add(new MaterialDocument(Guid.NewGuid(), "360456789", 5, Guid.NewGuid() ));
            _materialDocuments.Add(new MaterialDocument(Guid.NewGuid(), "360456789", 10, Guid.NewGuid()));
            _materialDocuments.Add(new MaterialDocument(Guid.NewGuid(), "360456789", -3, Guid.NewGuid()));
            _materialDocuments.Add(new MaterialDocument(Guid.NewGuid(), "360456790", 10, Guid.NewGuid()));
        }

        public async Task AddAsync(MaterialDocument materialDocument)
        {
            _materialDocuments.Add(materialDocument);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<MaterialDocument>> BrowseAsync(string materialNumber = "", string sectorName = "", string productionOrder = "")
        {
            return await Task.FromResult(_materialDocuments.Where(x => x.MaterialNumber.Contains(materialNumber) && x.ProductionOrder.Contains(productionOrder)));
        }

        public async Task<MaterialDocument> GetAsync(Guid id)
        {
            return await Task.FromResult(_materialDocuments.SingleOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<MaterialDocument>> GetByMaterialAsync(string materialNumber)
        {
            return await Task.FromResult(_materialDocuments.Where(x => x.MaterialNumber.Contains(materialNumber)));
        }

        public async Task<IEnumerable<MaterialDocument>> GetByProductionOrderAsync(string productionOrder)
        {
            return await Task.FromResult(_materialDocuments.Where(x => x.ProductionOrder == productionOrder));
        }

        public async Task<IEnumerable<MaterialDocument>> GetBySectorAsync(Guid sectorId)
        {
            return await Task.FromResult(_materialDocuments.Where(x => x.SectorId == sectorId));
        }
    }
}