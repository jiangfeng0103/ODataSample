using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;
using WebApiODataV4.Models;

namespace WebApiODataV4.Controllers
{
    public class SuppliersController : ODataController
    {
        private readonly V4DbContext _dbContext = new V4DbContext();

        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return _dbContext.Suppliers.Where(m => m.Id.Equals(key)).SelectMany(m => m.Products);
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}