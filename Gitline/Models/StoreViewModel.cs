using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gitline.Models
{
    public class StoreViewModel
    {
        public List<Inventory> ProductList { get; set; }

        public int Quantity { get; set; }

        public Inventory Product { get; set; }

        public List<ProductOrder> CartList { get; set; }
    }
}
