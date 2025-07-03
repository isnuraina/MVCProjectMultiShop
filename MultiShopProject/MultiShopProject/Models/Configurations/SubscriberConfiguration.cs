using Bigon.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.WebUI.Models.Persistences.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(m => m.Email).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(m => m.Approved).HasColumnType("bit").IsRequired();
            builder.Property(m => m.ApprovedAt).HasColumnType("datetime");
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.HasKey(m => m.Email);
            builder.ToTable("Subscribers");
        }
    }
}
