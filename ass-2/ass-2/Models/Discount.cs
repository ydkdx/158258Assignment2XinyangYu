using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ass_2.Models
{
    public class Discount
    {
        [Key]
        public string Name { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal CurrentPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}