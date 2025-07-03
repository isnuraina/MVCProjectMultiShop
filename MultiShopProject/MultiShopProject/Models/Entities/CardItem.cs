using MultiShopProject.Models.Entities.Commons;

namespace MultiShopProject.Models.Entities
{
    public class CardItem:BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
