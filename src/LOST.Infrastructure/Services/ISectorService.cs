using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LOST.Core.Domain;

namespace LOST.Infrastructure.Services
{
    public interface ISectorService: IService
    {
        Task CreateAsync(Guid sectorId, string name);
        Task <IEnumerable<Sector>> BrowseAsync();
    }
}