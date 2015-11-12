using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiODataV4.Models
{
    /// <summary>
    /// 产品
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}