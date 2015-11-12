using WebApiODataV4.Models;

namespace WebApiODataV4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiODataV4.Models.V4DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApiODataV4.Models.V4DbContext context)
        {
            if (!context.Products.Any())
            {
                var suplier = new Supplier { Name = "新华出版社" };

                var product = new Product { Category = "IT", Name = "一统", Price = 1688, Supplier = suplier };
                context.Products.Add(product);
                suplier = new Supplier { Name = "教育出版社" };
                product = new Product { Category = "股票", Name = "股市", Price = 1688, Supplier = suplier };
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
    }
}
