using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiShopProject.Models.Entities;

namespace MultiShopProject.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Descrption).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.ImageURL).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.OldPrice).HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Products");
        }
    }
}
