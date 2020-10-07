
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FreshProduceShop.Models
{   public class ProduceRepository: IProduceRepository
    {
        private readonly ProduceDbContext _produceDbContext;
        public ProduceRepository (ProduceDbContext produceDbContext)
        {
            _produceDbContext = produceDbContext;
        }

        public IEnumerable<Produce> GetAllProduces
        {
            get
            {
                return _produceDbContext.Produces.Include( c => c.Category);
            }
        }

        public IEnumerable<Produce> GetAllProducesofTheWeek
        {
            get
            {
                return _produceDbContext.Produces.Include( c => c.Category).Where(f=>f.IsProduceOfTheWeek);
            }
        }

        public Produce GetProduceById(int produceId)
        {
            return _produceDbContext.Produces.FirstOrDefault(p =>p.ProduceId ==produceId);
        }
    }
}