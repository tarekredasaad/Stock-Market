using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using Stock_Models;
using System.Threading.Tasks;

namespace StockMarket.MyHub
{
    public class RandomNumber:Hub
    {
        public async Task SendRandomNumber()
        {
            //List<Stock> stocks = C;
            var random = new Random();
            var randomNumber = random.Next(1, 100);
            var timer = new Timer((state) => {
                // Generate a random integer between -100 and 100
                randomNumber = random.Next(-100, 101);
                Console.WriteLine($"New value: {randomNumber}");
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            await Clients.All.SendAsync("newRandomNumber", randomNumber);
        }

        //public async Task update()
        //{
        //    List<>
        //}
    }
}
