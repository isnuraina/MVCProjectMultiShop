using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiShopProject.Models.Entities;

namespace MultiShopProject.Models.Configurations
{
    public class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
    {
        public void Configure(EntityTypeBuilder<Sponsor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ImageUrl).HasMaxLength(255).IsRequired();
            builder.ToTable("Sponsors");
        }
    }
}
