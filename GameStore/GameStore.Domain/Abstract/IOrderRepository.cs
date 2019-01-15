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
        void SaveOrder(Order order);
        Order DeleteOrder(int orderId);
        //void CreateOrder(Cart cart, Order order);
    }
}
