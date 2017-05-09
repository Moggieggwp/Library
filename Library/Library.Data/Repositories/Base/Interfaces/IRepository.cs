using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Base.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
       // Task<T> FindByIdAsync(int id);
        void Add(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
