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

        public virtual Inventory Product { get; set; }

        public int? ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total { get; set; }

    }
}
