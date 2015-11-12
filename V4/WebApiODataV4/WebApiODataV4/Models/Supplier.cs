using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiODataV4.Models
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}