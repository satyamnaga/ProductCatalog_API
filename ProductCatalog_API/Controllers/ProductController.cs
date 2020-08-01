using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog_API.DAL;
using ProductCatalog_API.Models;

namespace ProductCatalog_API.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        //[Produces("application/json")]
        [HttpGet("getall")]
        public List<Product> Get()
        {
            return _context.products.ToList();
        }
        [HttpGet("({ID})")]
        public Product EditProduct(int ID)
        {
            var product = _context.products.Where(x => x.ID == ID).SingleOrDefault();
            return product;
        }
        [HttpPost]
        public IActionResult EditProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.products.Update(product);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("({ID})")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}