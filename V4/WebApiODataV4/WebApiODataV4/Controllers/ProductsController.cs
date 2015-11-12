using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using WebApiODataV4.Models;

namespace WebApiODataV4.Controllers
{
    public class ProductsController : ODataController
    {
        private readonly V4DbContext _dbContext = new V4DbContext();

        private bool Exists(int key)
        {
            return _dbContext.Products.Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return _dbContext.Products;
        }

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            IQueryable<Product> result = _dbContext.Products.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return Created(product);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await _dbContext.Products.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Product update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(update).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await _dbContext.Products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [EnableQuery]
        public SingleResult<Supplier> GetSupplier([FromODataUri] int key)
        {
            var result = _dbContext.Products.Where(m => m.Id == key).Select(m => m.Supplier);
            return SingleResult.Create(result);
        }



        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}