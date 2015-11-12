using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiODataV4.Models
{
    public class ProductRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } 
    }
}