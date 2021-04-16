using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Gitline.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Required. ")]
        public string OrderAddress { get; set; }
        [Required(ErrorMessage = "Required. ")]
        public string OrderCity { get; set; }
        [Required(ErrorMessage = "Required. ")]
        public int OrderZip { get; set; }
        public DateTime dateTime { get; set; }
        [Required(ErrorMessage = "Required. ")]
        public int OrderPhone { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid format. ")]
        [Required(ErrorMessage = "Required. ")]
        public string OrderEmail { get; set; }
        public int OrderRate { get; set; }
        [Required(ErrorMessage = "Required. ")]

        public string OrderUser { get; set; }

        public virtual ProductOrder Product { get; set; }


    }
}
