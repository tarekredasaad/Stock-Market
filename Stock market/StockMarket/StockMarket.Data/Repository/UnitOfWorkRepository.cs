using Stock_Models.Interfaces;
using Stock_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Data.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public Context Context { get; set; }
        public IRepository<Stock> Stock { get; private set; }

        public IRepository<Order> Order { get; private set; }

        public UnitOfWorkRepository(Context context) 
        {
            Context = context;
            Stock = new Repository<Stock>(Context);
            Order = new Repository<Order>(Context);
        }

        public void Complete()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
