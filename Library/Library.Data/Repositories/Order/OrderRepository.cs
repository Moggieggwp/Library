using Library.Data.Context;
using Library.Data.Repositories.Order.Interface;
using System.Data.Entity;
using Library.Data.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library.Data.Repositories.Order
{
    public class OrderRepository : Repository<Entities.Order>, IOrderRepository
    {
        private readonly IDbSet<Entities.Order> orderDataSet;

        public OrderRepository(IDataContext dataContext) : base(dataContext)
        {
            this.orderDataSet = dataContext.Set<Entities.Order>();
        }

        public void BookOrder(Entities.Order order)
        {
            orderDataSet.Add(order);
            SaveChanges();
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
