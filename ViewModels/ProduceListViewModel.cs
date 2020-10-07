using System.Collections.Generic;
using FreshProduceShop.Models;

namespace FreshProduceShop.ViewModels
{
    public class ProduceListViewModel
    {
        //add property for data to be displayed in the view
        public IEnumerable<Produce>  Produces{ get; set; }
        public string CurrentCategory { get; set; }
    }
}