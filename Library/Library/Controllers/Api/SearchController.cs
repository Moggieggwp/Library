using Library.Data.Entities;
using Library.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Library.Controllers.Api
{
    public class SearchController : ApiController
    {
        private readonly IDbSet<Book> entityDataSet;

        public SearchController(DbContext databaseContext)
        {
            entityDataSet = databaseContext.Set<Book>();
        }

        [HttpGet]
        public Test GetItems(string searchText)
        {
            var book = entityDataSet.FirstOrDefault();
            return new Test { Id = book.Id, Name = book.Title };
        }
    }
}
