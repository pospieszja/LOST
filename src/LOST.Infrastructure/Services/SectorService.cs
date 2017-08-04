using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LOST.Core.Domain;
using LOST.Core.Repositories;

namespace LOST.Infrastructure.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;        

        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<IEnumerable<Sector>> BrowseAsync()
        {
            return await _sectorRepository.GetAllAsync();
        }

        public async Task CreateAsync(Guid sectorId, string name)
        {

            var sector = await _sectorRepository.GetByNameAsync(name);
            if (sector != null)
            {
                 throw new Exception($"Sector {name} already exist.");
            } 

            sector = new Sector(sectorId, name);
            await _sectorRepository.AddAsync(sector);
        }
    }
}