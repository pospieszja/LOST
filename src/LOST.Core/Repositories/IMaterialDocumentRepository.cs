using LOST.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOST.Core.Repositories
{
    public interface IMaterialDocumentRepository
    {
        Task<MaterialDocument> GetAsync(Guid id);
        Task<IEnumerable<MaterialDocument>> GetByMaterialAsync(string materialNumber);
        Task<IEnumerable<MaterialDocument>> GetByProductionOrderAsync(string productionOrder);
        Task AddAsync(MaterialDocument materialDocument);
    }
}