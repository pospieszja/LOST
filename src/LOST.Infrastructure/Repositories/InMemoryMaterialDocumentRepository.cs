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
            _materialDocuments.Add(new MaterialDocument(guid, "360456789", 5, new Sector(Guid.NewGuid(), "sektor C")));
            _materialDocuments.Add(new MaterialDocument(guid, "360456789", 10, new Sector(Guid.NewGuid(), "sektor C")));
        }

        public async Task AddAsync(MaterialDocument materialDocument)
        {
            _materialDocuments.Add(materialDocument);
            await Task.CompletedTask;
        }

        public async Task<MaterialDocument> GetAsync(Guid id)
        {
            return await Task.FromResult(_materialDocuments.SingleOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<MaterialDocument>> GetByMaterialAsync(string materialNumber)
        {
            return await Task.FromResult(_materialDocuments.Where(x => x.MaterialNumber == materialNumber));
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