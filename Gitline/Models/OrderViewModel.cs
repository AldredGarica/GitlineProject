using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gitline.Models
{
    public class OrderViewModel
    {
        public List<ProductOrder> ProductList { get; set; }

        public ProductOrder Order { get; set; }

        public List<Order> OrderList { get; set; }


    }
}
