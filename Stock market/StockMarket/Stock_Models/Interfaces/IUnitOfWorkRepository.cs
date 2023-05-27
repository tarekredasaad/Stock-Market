using Stock_Models.Model;
using StockMarket.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Models.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IRepository<Stock> Stock { get; }
        IRepository<Order> Order { get; }
    }
}
