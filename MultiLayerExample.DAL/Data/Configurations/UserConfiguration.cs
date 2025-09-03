using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayerExample.Domain.Entities;

namespace MultiLayerExample.DAL.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users", "Test");

            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("ID");

            entity.HasData(
                new User { Id = 1, FullName = "John Doe"},
                new User { Id = 2, FullName = "Petrenko Petro"});
        }
    }
}
