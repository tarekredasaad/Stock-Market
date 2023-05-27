using Microsoft.AspNetCore.Mvc;
using Stock_Models.Interfaces;
using StockMarket.DTO;
using StockMarket.MyHub;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Stock_Models.Model;

namespace StockMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IHubContext<OrderHub> _hub;
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public OrderController(IUnitOfWorkRepository unitOfWorkRepository, IHubContext<OrderHub> hub)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            _hub = hub;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetOrder()
        //{
        //    Order order =(Order) unitOfWorkRepository.Order.GetAll().LastOrDefault();
        //    //var randomNumber = random.Next(1, 100);
        //    //await _hub.Clients.All.SendAsync("OrderAdded", order);
        //    return Ok(order);
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var random = new Random();
            var randomNumber = random.Next(1, 100);
            return Ok(randomNumber);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders() 
        {
            IEnumerable<Order> orders = await unitOfWorkRepository.Order.GetAll("Stock");
            return Ok(orders);
        }


        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(OrderDTO orderDTO) 
        {
            if(ModelState.IsValid)
            {
                Order order = new Order();
                order.StockID = orderDTO.StockID;
                Stock stock = await unitOfWorkRepository.Stock.GetById(order.StockID);
                order.Price = stock.Price;
                order.Quantity = orderDTO.Quantity;
                order.PersonName = orderDTO.PersonName;

                unitOfWorkRepository.Order.Add(order);
               
                return Ok("order has inserted successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        
    }
}
