using Library.Data.Repositories.Order.Interface;
using Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Data.Entities;
using System.Threading.Tasks;
using Library.ViewModels;
using Library.Data.DTOs;

namespace Library.Services
{
    public class ManageOrdersService : IManageOrdersService
    {
        private readonly IOrderRepository orderRepository;
        public ManageOrdersService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void BookOrder(Order order)
        {
            orderRepository.BookOrder(order);
        }

        public async Task<List<OrderViewModel>> GetOrdersForUser(string userEmail)
        {
            var orders = await orderRepository.GetOrdersForUser(userEmail);
            var orderViewModel = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                if (order.Books.Count == 0)
                    continue;

                orderViewModel.Add(new OrderViewModel
                {
                    Book = CreateBookDTO(order.Books.FirstOrDefault()),
                    OrderDate = order.OrderDate,
                    ReturnDate = order.ReturnDate,
                    OrderId = order.Id
                });
            }

            return orderViewModel;
        }

        public async Task DeleteOrder(OrderViewModel orderViewModel)
        {
            var order = await orderRepository.GetOrderById(orderViewModel.OrderId);
            orderRepository.DeleteOrder(order);
        }

        private BookDTO CreateBookDTO(Book book)
        {
            return new BookDTO
            {
                BookId = book.Id,
                Title = book.Title,
                Description = book.Description,
                Fare = book.Fare,
                IssueYear = book.IssueYear.Date,
                Pages = book.Pages,
                ImageName = book.ImageName,
                PathToReadOnline = book.PathToReadOnline
            };
        }
    }
}