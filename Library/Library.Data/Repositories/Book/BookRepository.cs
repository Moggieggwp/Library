using Library.Data.Repositories.Base;
using Library.Data.Repositories.Book.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Library.Data.Context;

namespace Library.Data.Repositories.Book
{
    public class BookRepository : Repository<Entities.Book>, IBookRepository
    {
        private readonly IDbSet<Entities.Book> bookDataSet;

        public BookRepository(IDataContext dataContext) : base(dataContext)
        {
            this.bookDataSet = dataContext.Set<Entities.Book>();
        }

        public Task<List<Entities.Book>> GetBooksByPartialName(string partialName)
        {
            return bookDataSet
                .Where(x => (x.Title + " " + x.Description + " " + x.Genre).StartsWith(partialName)
                || (x.Title + " " + x.Description + " " + x.Genre).StartsWith(partialName.ToUpper())
                || (x.Title + " " + x.Description + " " + x.Genre).StartsWith(partialName.ToLower())
                || (x.Title + " " + x.Description + " " + x.Genre).Contains(partialName)
                || (x.Title + " " + x.Description + " " + x.Genre).Contains(partialName.ToUpper())
                || (x.Title + " " + x.Description + " " + x.Genre).Contains(partialName.ToLower()))
                .Where(x => x.Order == null)
                .ToListAsync();
        }

        public async Task<Entities.Book> GetBookById(int bookId)
        {
            return await bookDataSet
                .Include(x => x.Publisher)
                .Include(x => x.Writers.Select(z => z.Writer))
                .FirstOrDefaultAsync(x => x.Id == bookId && x.Order == null);
        }
    }
}
