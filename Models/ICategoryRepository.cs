using System.Collections.Generic;

namespace FreshProduceShop.Models
{
public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories{get;}
       
    }
}