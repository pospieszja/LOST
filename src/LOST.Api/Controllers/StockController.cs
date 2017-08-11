using System.Threading.Tasks;
using LOST.Infrastructure.Commands;
using LOST.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace LOST.Api.Controllers
{
 [Route("api/stock")]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> CheckStock([FromQuery]CheckStock command)
        {
            var stock = await _stockService.CheckStockAsync(command.MaterialNumber, command.SectorName, command.ProductionOrder);
            return Ok(stock);
        }
    }
}