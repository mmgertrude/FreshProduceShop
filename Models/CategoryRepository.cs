using System.Collections.Generic;

namespace FreshProduceShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProduceDbContext _produceDbContext;

        public CategoryRepository(ProduceDbContext produceDbContext)
        {
            _produceDbContext = produceDbContext;
        }

        public IEnumerable<Category> GetAllCategories => _produceDbContext.Categories;
    }
}