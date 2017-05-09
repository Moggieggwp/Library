using Library.Data.Entities;
using Library.Services.Interfaces;
using Library.ViewModels;
using System.Threading.Tasks;
using System.Web.Http;

namespace Library.Controllers.Api
{
    public class SearchController : ApiController
    {
        private readonly ISearchService searchService;

        public SearchController(
            ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<SearchResultViewModel> GetItems(string partialName)
        {
            return await searchService.GetItems(partialName);
        }

        [HttpGet]
        public async Task<BookInfoViewModel> GetDetailsInfo(int bookId)
        {
            return await searchService.GetDetailsInfo(bookId);
        }
    }
}
