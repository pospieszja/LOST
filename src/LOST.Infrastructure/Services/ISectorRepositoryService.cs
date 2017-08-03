using System;
using System.Threading.Tasks;
using LOST.Core.Domain;

namespace LOST.Infrastructure.Services
{
    public interface ISectorRepositoryService: IService
    {
         Task GetAsync(Guid id);
         Task CreateAsync(string sectorName);
         Task RemoveAsync(string sectorName);
    }
}