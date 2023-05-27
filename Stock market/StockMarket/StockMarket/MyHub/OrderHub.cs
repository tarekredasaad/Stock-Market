using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using StockMarket.DTO;
using Stock_Models;
using StockMarket.Data;
using Stock_Models.Model;

namespace StockMarket.MyHub
{
    public class OrderHub:Hub
    {
        public Context Context { get; }
        public OrderHub(Context context)
        {
            Context = context;
        }

        public  async void NewOrder(string name,string price,string quantity, string stockName) //,string stockName
        {
           //Order order1 = Context.Orders.LastOrDefault();
           await Clients.All.SendAsync("OrderAdded", name, price,quantity, stockName);

        }
        
        public async void NewPrice(string stockId)
        {
            decimal price;
            Stock stock = Context.Stocks.Find(int.Parse(stockId));
            price = stock.Price;
           await Clients.All.SendAsync("Price", price);

        }



        //public async Task SendRandomNumber(int number)
        //{
        //    await Clients.All.SendAsync("newRandomNumber", number);
        //}
    }
}
