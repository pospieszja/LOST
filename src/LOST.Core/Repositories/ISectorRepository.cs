using LOST.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOST.Core.Repositories
{
    public interface ISectorRepository : IRepository
    {
        Task<Sector> GetAsync(Guid id);
        Task<Sector> GetByNameAsync(string name);
        Task<IEnumerable<Sector>> GetAllAsync();
        Task AddAsync(Sector sector);
        Task RemoveAsync(Guid id);
    }
}
