using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreshProduceShop.Models
{
public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }
        [Required]
        public List<Produce> Produces { get; set; }
        




    }
}