using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Data.Repository
{
    public interface IRepository<T>
    {
        public  Task<IEnumerable<T>> GetAll();

        public  Task<IEnumerable<T>> GetAll(string obj);
        public Task<T> Add(T item);

        public Task<T> GetLast();

        public Task<T> update(T item);

        public Task<T> GetById(int id);
    }
}
