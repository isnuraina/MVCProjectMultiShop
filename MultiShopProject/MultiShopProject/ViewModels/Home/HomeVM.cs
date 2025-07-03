using MultiShopProject.Models.Entities;

namespace MultiShopProject.ViewModels.Home
{
    public class HomeVM
    {
        public List<CarouselItem> CarouselItems { get; set; }
        public List<CardItem> CardItems { get; set; }
        public List<Sponsor> Sponsors { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
