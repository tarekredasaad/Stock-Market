using Microsoft.AspNetCore.Mvc;
using Stock_Models.Interfaces;
using Stock_Models.Model;
using StockMarket.DTO;

namespace StockMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public StockController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            IEnumerable<Stock> stocks = await unitOfWorkRepository.Stock.GetAll();
            return Ok(stocks);
        }

        [HttpPost]
        public IActionResult AddStock(StockDTO stockDTO)
        {
            if(ModelState.IsValid)
            {
                var stock = new Stock();
                stock.Name = stockDTO.Name;
                stock.Price = stockDTO.Price;
                unitOfWorkRepository.Stock.Add(stock);
                return Ok("stock has added successfully");
            }
            else
            {
                return BadRequest("Add operation has been failed");
            }
        }

        [HttpPut]
        public async Task<IActionResult> updateStockPrice(int stockId,decimal price)
        {
            if (price != null)
            {
                Stock stock = await unitOfWorkRepository.Stock.GetById(stockId);
                stock.Price = price;
                await unitOfWorkRepository.Stock.update(stock);
                return Ok("Stock has been updated successfully");
            }
            else
            {
                return BadRequest("update operation has been failed");
            }
        }
    }
}
