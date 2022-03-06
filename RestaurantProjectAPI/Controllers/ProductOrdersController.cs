using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantProjectAPI.DBContext;
using RestaurantProjectAPI.Models;

namespace RestaurantProjectAPI.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ProductOrdersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductOrdersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/GetProductOrders
        [HttpGet("GetProductOrders")]
        public async Task<ActionResult<IEnumerable<ProductOrder>>> GetProductOrders()
        {
            return await _context.ProductOrders.ToListAsync();
        }

        // GET: api/GetProductOrderById/5
        [HttpGet("GetProductOrderById{id}")]
        public async Task<ActionResult<ProductOrder>> GetProductOrder(int id)
        {
            var productOrder = await _context.ProductOrders.FindAsync(id);

            if (productOrder == null)
            {
                return NotFound();
            }

            return productOrder;
        }

        // PUT: api/v1/UpdateProductOrder/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("UpdateProductOrder{id}")]
        public async Task<IActionResult> PutProductOrder(int id, ProductOrder productOrder)
        {
            if (id != productOrder.ProductOrderId)
            {
                return BadRequest();
            }

            _context.Entry(productOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOrderExists(id))
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

        // POST: api/v1/CreateProductOrder
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("CreateProductOrder")]
        public async Task<ActionResult<ProductOrder>> PostProductOrder(ProductOrder productOrder)
        {
            _context.ProductOrders.Add(productOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductOrder", new { id = productOrder.ProductOrderId }, productOrder);
        }

        // DELETE: api/v1/DeleteProductOrder/5
        [HttpDelete("DeleteProductOrder{id}")]
        public async Task<ActionResult<ProductOrder>> DeleteProductOrder(int id)
        {
            var productOrder = await _context.ProductOrders.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            _context.ProductOrders.Remove(productOrder);
            await _context.SaveChangesAsync();

            return productOrder;
        }

        private bool ProductOrderExists(int id)
        {
            return _context.ProductOrders.Any(e => e.ProductOrderId == id);
        }
    }
}
