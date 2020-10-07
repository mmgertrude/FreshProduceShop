using System.Collections.Generic;

namespace FreshProduceShop.Models
{
public interface IProduceRepository
    {
        IEnumerable<Produce> GetAllProduces{get;}
        IEnumerable<Produce> GetAllProducesofTheWeek{get;}
        Produce GetProduceById(int produceId);

    }
}