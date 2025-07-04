using MultiShopProject.Models.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace MultiShopProject.Models.Entities
{
    public class Product : BaseEntity
    {
        
        public string Name { get; set; }

        public string Title { get; set; }

        public string Descrption { get; set; }

        public string ImageURL { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public decimal OldPrice { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
