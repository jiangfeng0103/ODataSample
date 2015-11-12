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
                var suplier = new Supplier { Name = "�»�������" };

                var product = new Product { Category = "IT", Name = "һͳ", Price = 1688, Supplier = suplier };
                context.Products.Add(product);
                suplier = new Supplier { Name = "����������" };
                product = new Product { Category = "��Ʊ", Name = "����", Price = 1688, Supplier = suplier };
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
    }
}
