using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Abstract;

namespace GameStore.Domain.Concrete
{
    public class EFCompositionOrderRepository : ICompositionOrderRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<CompositionOrder> CompositionOrders
        {
            get { return context.CompositionOrders; }
        }
        public void CreateCompositionOrder(Order order, Cart cart)
        {

            foreach (var c in cart.Lines)
            {
                CompositionOrder compOrder = new CompositionOrder();
                compOrder.Count = c.Quantity;
                compOrder.GameID = c.Game.GameId;
                compOrder.OrderID = order.OrderID;
                context.CompositionOrders.Add(compOrder);
            }            
            context.SaveChanges();
        }
        //else
            //{
            //    Order dbEntry = context.Orders.Find(order.OrderID);
            //    if (dbEntry != null)
            //    {
            //        dbEntry.RecipientName = order.RecipientName;
            //        dbEntry.Adress = order.Adress;
            //        dbEntry.Town = order.Town;
            //        dbEntry.Country = order.Country;
            //        dbEntry.Price = order.Price;
            //        dbEntry.Status = order.Status;
            //        dbEntry.Date = DateTime.Now;
            //    }
            //}
        //public CompositionOrder DeleteCompositionOrder(int orderId = 7)
        //{
        //    CompositionOrder dbEntry = context.CompositionOrders.Find(orderId);
        //    if (dbEntry != null)
        //    {
        //        context.CompositionOrders.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //    return dbEntry;
        //}
    }
}
