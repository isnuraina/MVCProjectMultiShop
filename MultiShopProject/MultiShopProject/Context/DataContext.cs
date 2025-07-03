using Bigon.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using MultiShopProject.Models.Entities;

namespace MultiShopProject.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
        public DbSet<CarouselItem> CarouselItems { get; set; }
        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

    }
}
