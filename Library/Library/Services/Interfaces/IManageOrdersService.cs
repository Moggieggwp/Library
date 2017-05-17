using Library.Data.Entities;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Library.Services.Interfaces
{
    public interface IManageOrdersService
    {
        void BookOrder(Order order);
        Task<List<OrderViewModel>> GetOrdersForUser(string userEmail);
    }
}