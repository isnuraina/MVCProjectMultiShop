using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiShopProject.Models.Entities;

namespace MultiShopProject.Models.Configurations
{
    public class CardItemConfiguration : IEntityTypeConfiguration<CardItem>
    {
        public void Configure(EntityTypeBuilder<CardItem> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m=>m.ImageUrl).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m=>m.Title).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m=>m.Description).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.HasKey(m => m.Id);
            builder.ToTable("CardItems");
        }
    }
}
