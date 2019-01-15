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
    }
}
