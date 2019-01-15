using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    public interface ICompositionOrderRepository
    {
        IEnumerable<CompositionOrder> CompositionOrders { get; }
        void CreateCompositionOrder(Order order, Cart cart);
    }
}
