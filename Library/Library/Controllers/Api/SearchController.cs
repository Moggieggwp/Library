using EasyFlights.Web.Infrastructure;
using Library.Data.Entities;
using Library.Data.Repositories.Book.Interfaces;
using Library.Services.Interfaces;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Web.Http;

namespace Library.Controllers.Api
{
    public class SearchController : ApiController
    {
        private readonly ISearchService searchService;
        private readonly IApplicationUserManager applicationUserManager;
        private readonly IBookRepository bookRepository;
        private readonly IManageOrdersService manageOrderService;

        public SearchController(
            ISearchService searchService,
            IApplicationUserManager applicationUserManager,
            IBookRepository bookRepository,
            IManageOrdersService manageOrderService)
        {
            this.searchService = searchService;
            this.applicationUserManager = applicationUserManager;
            this.bookRepository = bookRepository;
            this.manageOrderService = manageOrderService;
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

        [HttpGet]
        public async Task<List<OrderViewModel>> GetOrdersForUser()
        {
            return await manageOrderService.GetOrdersForUser(User.Identity.Name);
        }

        [HttpPost]
        public async Task<bool> OrderBook([FromBody]int bookId)
        {
            try
            {
                var orderDate = DateTime.UtcNow;
                var returnDate = DateTime.UtcNow.AddDays(7);
                var user = await applicationUserManager.FindByEmailAsync(User.Identity.Name);
                var book = await bookRepository.GetBookById(bookId);

                var order = new Order
                {
                    OrderDate = orderDate,
                    Books = new List<Book> { book },
                    User = user,
                    ReturnDate = returnDate
                };

                manageOrderService.BookOrder(order);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
