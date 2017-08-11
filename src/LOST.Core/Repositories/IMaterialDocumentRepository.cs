using LOST.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOST.Core.Repositories
{
    public interface IMaterialDocumentRepository : IRepository
    {
        Task<MaterialDocument> GetAsync(Guid id);
        Task<IEnumerable<MaterialDocument>> GetByMaterialAsync(string materialNumber);
        Task<IEnumerable<MaterialDocument>> GetByProductionOrderAsync(string productionOrder);

        Task<IEnumerable<MaterialDocument>> BrowseAsync(string materialNumber = "", string sectorName = "", string productionOrder = "");
        Task AddAsync(MaterialDocument materialDocument);
    }
}