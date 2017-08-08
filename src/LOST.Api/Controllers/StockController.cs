using System.Threading.Tasks;
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
        public async Task<IActionResult> CheckStock()
        {
            var stock = await _stockService.CheckStockAsync("360456789");
            return Ok(stock);
        }
    }
}