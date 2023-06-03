using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using Stock_Models;
using StockMarket.Data;
using System.Threading.Tasks;
using Stock_Models.Model;

namespace StockMarket.MyHub
{
    public class RandomNumber:Hub
    {
        Context context;
        public RandomNumber(Context context) 
        {
            this.context = context;
        }

        public async Task SendRandomNumber()
        {
            
            List<Stock> stocks = context.Stocks.ToList();
            var random = new Random();
            var randomNumber = random.Next(1, 100);
            var timer = new Timer((state) => {
                // Generate a random integer between -100 and 100
                randomNumber = random.Next(-100, 101);
                Console.WriteLine($"New value: {randomNumber}");
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            await Clients.All.SendAsync("newRandomNumber", stocks);
        }

        //public async Task update()
        //{
        //    List<>
        //}
    }
}
