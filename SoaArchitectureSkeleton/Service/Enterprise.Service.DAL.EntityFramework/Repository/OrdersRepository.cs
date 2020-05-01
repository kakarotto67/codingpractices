using System;
using System.Linq;
using Enterprise.Service.DAL.Shared.Repository;

namespace Enterprise.Service.DAL.EntityFramework.Repository
{
    public class OrdersRepository : IRepository<Order>
    {
        private readonly NorthwindContext databaseContext;

        public OrdersRepository()
        {
            databaseContext = new NorthwindContext();
        }

        public Order GetEntityById(Int32 id)
        {
            return databaseContext.Orders.FirstOrDefault(order => order.OrderID == id);
        }
    }
}
