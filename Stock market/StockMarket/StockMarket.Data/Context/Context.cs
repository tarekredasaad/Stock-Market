using Stock_Models.Model;
using Microsoft.EntityFrameworkCore;
namespace StockMarket.Data
{
    public class Context : DbContext  
    {
        public Context(): base()
        {
        
        }

        public Context(DbContextOptions options) : base(options) 
        {
        
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}