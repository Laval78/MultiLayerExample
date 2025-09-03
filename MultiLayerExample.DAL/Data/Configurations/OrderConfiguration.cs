using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.DAL.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("Orders", "Test");

            entity.HasKey(o => o.Id);
            entity.Property(o => o.Id).HasColumnName("ID");
            entity.Property(o => o.IdUser).HasColumnName("ID_User");
            entity.Property(o => o.TotalAmount).HasPrecision(18, 2);

            entity.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_User");

            entity.HasData(
                new Order { Id = 1, IdUser = 1, TotalAmount = 2350},
                new Order { Id = 2, IdUser = 2, TotalAmount = 2350});

            entity
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity<Dictionary<string, object>>(
                "OrderProducts",
                j => j.HasData(
                    new { OrdersId = 1, ProductsId = 1 },
                    new { OrdersId = 1, ProductsId = 2 },
                    new { OrdersId = 2, ProductsId = 1 },
                    new { OrdersId = 2, ProductsId = 2 }
                )
            );
        }
    }
}
