using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOST.Core.Domain;
using LOST.Core.Repositories;

namespace LOST.Infrastructure.Repositories
{
    public class InMemorySectorRepository : ISectorRepository
    {
        private static readonly ISet<Sector> _sectors = new HashSet<Sector>();

        public async Task AddAsync(Sector sector)
        {
            _sectors.Add(sector);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Sector>> GetAllAsync()
        {
            return await Task.FromResult(_sectors);
        }

        public async Task<Sector> GetAsync(Guid id)
        {
            return await Task.FromResult(_sectors.SingleOrDefault(x => x.Id == id));
        }

        public async Task<Sector> GetByNameAsync(string name)
        {
            return await Task.FromResult(_sectors.SingleOrDefault(x => x.Name == name.ToLowerInvariant()));
        }

        public async Task RemoveAsync(Guid id)
        {
            var sector = await GetAsync(id);
            _sectors.Remove(sector);
            await Task.CompletedTask;
        }
    }
}