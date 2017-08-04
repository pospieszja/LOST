using System;
using System.Threading.Tasks;
using LOST.Infrastructure.Commands;
using LOST.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace LOST.Api.Controllers
{
    [Route("api/sectors")]
    public class SectorsController : Controller
    {
        private readonly ISectorService _sectorService;
        public SectorsController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSectors()
        {
            var sectors = await _sectorService.BrowseAsync();
            return Ok(sectors);
        }

        [HttpPost]
        public async Task<IActionResult> AddMachine([FromBody]CreateSector command)
        {
            await _sectorService.CreateAsync(Guid.NewGuid(), command.Name);
            return Created("", null);
        }
    }
}