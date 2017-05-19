using Library.Data.Context;
using Library.Data.Repositories.Order.Interface;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Library.Data.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Library.Data.Entities;
using System;

namespace Library.Data.Repositories.Order
{
    public class OrderRepository : Repository<Entities.Order>, IOrderRepository
    {
        private readonly IDbSet<Entities.Order> orderDataSet;
        private readonly IDbSet<Entities.Book> bookDataSet;

        public OrderRepository(IDataContext dataContext) : base(dataContext)
        {
            this.orderDataSet = dataContext.Set<Entities.Order>();
            this.bookDataSet = dataContext.Set<Entities.Book>();
        }

        public void BookOrder(Entities.Order order)
        {
            orderDataSet.Add(order);
            SaveChanges();
        }

        public void DeleteOrder(Entities.Order order)
        {
            var book = bookDataSet.FirstOrDefault(x => x.Order.Id == order.Id);
            book.Order = null;
            bookDataSet.AddOrUpdate(book);
            SaveChanges();
            orderDataSet.Remove(order);
            SaveChanges();
        }

        public async Task<Entities.Order> GetOrderById(long orderId)
        {
            return await orderDataSet.FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<List<Entities.Order>> GetOrdersForUser(string userEmail)
        {
            return await orderDataSet
                .Include(b => b.Books)
                .Where(x => x.User.Email == userEmail)
                .ToListAsync();
        }
    }
}
