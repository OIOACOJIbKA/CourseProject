using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        //void ProcessOrder(Cart cart, Order order);
        void CreateOrder(Order order);
        //void CreateOrder(Cart cart, Order order);
        //void CreateOrder(String recipientName, String adress, String town, String country);
    }
}
