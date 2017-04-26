using Library.Data.Repositories.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext dataContext;

        public Repository(DbContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(T entity)
        {
            this.dataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.dataContext.Set<T>().Remove(entity);
        }

        //public async Task<T> FindByIdAsync(int id)
        //{
        //    return await this.GetAll().FirstOrDefaultAsync(entity => entity.Id == id);
        //}

        public IQueryable<T> GetAll()
        {
            return this.dataContext.Set<T>().AsQueryable();
        }

        public void SaveChanges()
        {
            this.dataContext.SaveChanges();
        }
    }
}
