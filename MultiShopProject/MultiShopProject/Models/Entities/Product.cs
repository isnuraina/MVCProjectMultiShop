using MultiShopProject.Models.Entities.Commons;

namespace MultiShopProject.Models.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Descrption { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
