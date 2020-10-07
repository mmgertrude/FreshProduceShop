using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshProduceShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Produce Produce { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
