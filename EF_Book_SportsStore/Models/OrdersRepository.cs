using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Book_SportsStore.Models
{
    public class OrdersRepository : IOrdersRepository
    {
        private DataContext context;
        public OrdersRepository(DataContext context) => this.context = context;

        public IEnumerable<Order> Orders => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);

        public Order GetOrder(Guid orderId) => context.Orders.Include(o => o.Lines).FirstOrDefault(o => o.OrderId == orderId);

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            Order o = context.Orders.Find(order.OrderId);
            o.CustomerName = order.CustomerName;
            o.Adress = order.Adress;
            o.State = order.State;
            o.ZipCode = order.ZipCode;
            o.Shipped = order.Shipped;
            context.SaveChanges();
        }
    }
}
