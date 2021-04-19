using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gitline.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public virtual Order Order { get; set; }

        [Display(Name = "Please Rate the item (1-5)")]
        [Required(ErrorMessage = "Required. ")]
        public string Rate  { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
