using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Abstract;

namespace GameStore.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        EFDbContext context = new EFDbContext();


        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }
        public void SaveOrder(Order order)
        {
            if (order.OrderID == 0)
                context.Orders.Add(order);
            else
            {
                Order dbEntry = context.Orders.Find(order.OrderID);
                if (dbEntry != null)
                {
                    dbEntry.RecipientName = order.RecipientName;
                    dbEntry.Adress = order.Adress;
                    dbEntry.Town = order.Town;
                    dbEntry.Country = order.Country;
                    dbEntry.Price = order.Price;
                    dbEntry.Status = order.Status;
                    dbEntry.Date = DateTime.Now;
                }
            }
            context.SaveChanges();
        }
        //public void Status1(Order order)
        //{
        //    Order dbEntry = context.Orders.Find(order.OrderID);
        //    if (dbEntry != null)
        //    {
        //        dbEntry.Status = 1;
        //    }
        //    context.SaveChanges();
        //}
        public Order DeleteOrder(int orderId)
        {
            Order dbEntry = context.Orders.Find(orderId);
            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
