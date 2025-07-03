using MultiShopProject.Models.Entities.Commons;

namespace MultiShopProject.Models.Entities
{
    public class CarouselItem:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
