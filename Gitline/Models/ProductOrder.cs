using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gitline.Models
{
    public class ProductOrder
    {
        [Key]
        public int ProductOrderID { get; set; }
        public String ProductName { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }

        public int Total { get; set; }

    }
}
