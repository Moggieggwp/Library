using EasyFlights.Web.Infrastructure;
using EasyFlights.Web.ViewModels.AccountViewModels;
using Library.Data.Entities;
using Library.Data.Repositories.Book.Interfaces;
using Library.Services.Interfaces;
using Library.ViewModels;
using Microsoft.AspNet.Identity;
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

        [HttpGet]
        public async Task<UserInfoViewModel> GetUserInfo()
        {
            var user = await applicationUserManager.FindByEmailAsync(User.Identity.Name);

            return new UserInfoViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserEmail = user.Email
            };
        }

        [HttpGet]
        public string GetUserEmail()
        {
            return User.Identity.Name;
        }

        [HttpPost]
        public async Task<bool> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            if (model.NewPassword != model.NewPasswordConfirm)
            {
                return false;
            }

            ApplicationUser user = await applicationUserManager.FindByIdAsync(User.Identity.GetUserId());
            IdentityResult result = await applicationUserManager.ChangePasswordAsync(user.Id, model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        [HttpPost]
        public async Task<bool> ChangeAccountData([FromBody] UserInfoViewModel userInfo)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            var user = await applicationUserManager.FindByEmailAsync(userInfo.UserEmail);

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.PhoneNumber = userInfo.PhoneNumber;

            var result = await applicationUserManager.UpdateAsync(user);
            if (result.Succeeded)
                return true;

            return false;
        }
    }
}
