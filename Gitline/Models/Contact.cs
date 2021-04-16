using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gitline.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Sender Name")]
        [Required(ErrorMessage = "Required. ")]
        public string SenderName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid format. ")]
        [Required(ErrorMessage = "Required. ")]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Required. ")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required. ")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }



    }
}
