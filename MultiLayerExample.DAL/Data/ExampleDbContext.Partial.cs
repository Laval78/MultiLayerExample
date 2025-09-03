using Microsoft.EntityFrameworkCore;
using MultiLayerExample.DAL.Data.Configurations;

namespace MultiLayerExample.DAL.Data
{
    internal partial class ExampleDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
