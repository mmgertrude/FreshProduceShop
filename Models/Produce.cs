using System.ComponentModel.DataAnnotations;

namespace FreshProduceShop.Models
{
public class Produce
    {
        [Key]
        public int ProduceId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool InStock { get; set; }
        public bool IsProduceOfTheWeek { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        



    }
}