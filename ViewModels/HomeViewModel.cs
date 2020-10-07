using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreshProduceShop.Models;

namespace FreshProduceShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produce>  ProducesofTheWeek{ get; set; }
    }
}
