using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Book.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Entities.Book>> GetBooksByPartialName(string partialName);
    }
}
