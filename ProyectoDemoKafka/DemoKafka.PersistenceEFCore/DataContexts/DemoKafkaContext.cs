using DemoKafka.PersistenceEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoKafka.PersistenceEFCore.DataContexts
{
    internal class DemoKafkaContext : DbContext
    {
        public DemoKafkaContext(DbContextOptions options)
            : base(options) { }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<NotificationMessage> NotificationMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
