using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment1_redo1.Models;

namespace Assignment1_redo1.Controllers
{
    [Route("api/[controller]")] //the corresponding route from the program.cs file is specified here
    [ApiController]
    public class ProductController : ControllerBase //when an instance of this controller is created...
    {
        private readonly ProductDBContext _context;

        public ProductController(ProductDBContext context)//...this constructor will be invoked
        {
            _context = context; //the private readonly context is used to interact with the DB
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)//Compiles the ID of the parameter with the Id within the product instance
            {
                return BadRequest(); //else it will return a bad request with the status 404
            }

            _context.Entry(product).State = EntityState.Modified; //if the ids match then it will go for the update operation
            //in order to update an existing code inside entity framework we just need to specify the state of the record as .Modified
            try
            {
                await _context.SaveChangesAsync(); //then we just need to invoke this method savechangesasync so that the new changes within this pass object will be updated to the corresponding sql server record
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
