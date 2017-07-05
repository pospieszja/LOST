using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LOST.Core.Domain;
using LOST.Core.Repositories;

namespace LOST.Infrastructure.Repositories
{
    public class MaterialDocumentRepository : IMaterialDocumentRepository
    {
        public Task AddAsync(MaterialDocument materialDocument)
        {
            throw new NotImplementedException();
        }

        public Task<MaterialDocument> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MaterialDocument>> GetByMaterialAsync(string materialNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MaterialDocument>> GetByProductionOrderAsync(string productionOrder)
        {
            throw new NotImplementedException();
        }
    }
}