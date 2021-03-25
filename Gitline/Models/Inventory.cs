using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gitline.Models
{
    public class Inventory
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Required.")]
        public decimal Price { get; set; }

        public int Rating { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int Stock { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
    }
}
