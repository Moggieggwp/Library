using Library.Data.Entities;
using Library.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Library.Controllers.Api
{
    public class DefaultController : ApiController
    {
        private readonly IDbSet<Book> entityDataSet;

        public DefaultController(DbContext databaseContext)
        {
            entityDataSet = databaseContext.Set<Book>();
        }

        [HttpGet]
        public Test GetBook()
        {
            var book = entityDataSet.Include(x=> x.Publisher).FirstOrDefault();
            return new Test { Id = book.Id, Name = book.Title };
            //return new JsonResult
            //{ Data = test, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public void Post1(string value)
        {
            var book = entityDataSet.FirstOrDefault();
        }
    }
}
