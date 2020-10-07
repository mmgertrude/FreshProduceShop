using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshProduceShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProduceId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Produce Produce { get; set; }
        public Order Order { get; set; }
    }
}
