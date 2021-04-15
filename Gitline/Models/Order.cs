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
        public string OrderAddress { get; set; }    
        public string OrderCity { get; set; }
        public int OrderZip { get; set; }
        public DateTime dateTime { get; set; }
        public int OrderPhone { get; set; }
        public string OrderEmail { get; set; }
        public int OrderRate { get; set; }

        public string OrderUser { get; set; }


    }
}
