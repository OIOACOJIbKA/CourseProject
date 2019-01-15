using GameStore.Domain.Entities;
using System.Data.Entity;

namespace GameStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompositionOrder> CompositionOrders { get; set; }
    }
}