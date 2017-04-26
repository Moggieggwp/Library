using Library.Data.Repositories.Base;
using Library.Data.Repositories.Book.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Library.Data.Repositories.Book
{
    public class BookRepository : Repository<Entities.Book>, IBookRepository
    {
        private readonly IDbSet<Entities.Book> bookDataSet;

        public BookRepository(DbContext dataContext) : base(dataContext)
        {
            this.bookDataSet = dataContext.Set<Entities.Book>();
        }

        public Task<List<Entities.Book>> GetBooksByPartialName(string partialName)
        {
            return bookDataSet
                .Where(x => (x.Title + " " + x.Description).StartsWith(partialName)
                || (x.Title + " " + x.Description).StartsWith(partialName.ToUpper())
                || (x.Title + " " + x.Description).StartsWith(partialName.ToLower())
                || (x.Title + " " + x.Description).Contains(partialName)
                || (x.Title + " " + x.Description).Contains(partialName.ToUpper())
                || (x.Title + " " + x.Description).Contains(partialName.ToLower()))
                .ToListAsync();
        }
    }
}
