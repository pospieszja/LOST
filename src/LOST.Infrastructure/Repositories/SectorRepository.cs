using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LOST.Core.Domain;
using LOST.Core.Repositories;

namespace LOST.Infrastructure.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        public Task AddAsync(Sector sector)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sector>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Sector> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Sector> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}