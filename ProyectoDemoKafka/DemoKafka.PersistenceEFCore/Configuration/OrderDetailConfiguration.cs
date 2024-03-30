using DemoKafka.PersistenceEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoKafka.PersistenceEFCore.Configuration
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).HasPrecision(2);

            builder.HasKey(x => new { x.OrderId, x.ProductId });

            builder
                .HasOne(x => x.Order)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
