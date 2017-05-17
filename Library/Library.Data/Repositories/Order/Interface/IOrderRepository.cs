using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositories.Order.Interface
{
    public interface IOrderRepository
    {
        void BookOrder(Entities.Order order);
        Task<List<Entities.Order>> GetOrdersForUser(string userEmail);
    }
}
