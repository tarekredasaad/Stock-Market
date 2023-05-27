using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context Context;
        public Repository(Context _context)
        {
            Context = _context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAll(string obj)
        {
            return Context.Set<T>().Include(obj).ToList();
        }

        public async Task<T> Add(T item)
        {
            Context.Set<T>().Add(item);
            SaveChange();
            return item;
        }

        public async Task<T> GetLast()
        {
            return Context.Set<T>().LastOrDefault();
        }

        public async Task<T> GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public async Task<T> update(T item)
        {
            Context.Set<T>().Update(item);
            SaveChange();
            return item;
        }

        public void SaveChange()
        {
            Context.SaveChanges();
        }
    }
}
