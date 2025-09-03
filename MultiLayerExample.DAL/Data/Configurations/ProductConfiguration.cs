using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.DAL.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Products", "Test");

            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).HasColumnName("ID");
            entity.Property(p => p.Title).HasMaxLength(50);
            entity.Property(p => p.Price).HasPrecision(18, 2);

            entity.HasData(
                new Product { Id = 1, Title = "Iphone 16 pro", Price = 1350},
                new Product { Id = 2, Title = "Samsung s25", Price = 1000});
        }
    }
}
