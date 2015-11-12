using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiODataV4.Models
{
    public class V4DbContext : DbContext
    {
        public V4DbContext()
            : base("name=Default")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductRating> Ratings { get; set; }
    }
}