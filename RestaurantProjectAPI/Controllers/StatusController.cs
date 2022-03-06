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
    [Route("api/v1")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly MyDbContext _context;

        public StatusController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/GetStatus
        [HttpGet("GetStatus")]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

        // GET: api/v1/GetStatusById/1
        [HttpGet("GetStatusById{id}")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            var status = await _context.Status.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }

        // PUT: api/v1/UpdateStatus/2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("UpdateStatus{id}")]
        public async Task<IActionResult> PutStatus(int id, Status status)
        {
            if (id != status.Id)
            {
                return BadRequest();
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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

        // POST: api/v1/PostStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("PostStatus")]
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            _context.Status.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = status.Id }, status);
        }

        // DELETE: api/v1/UpdateStatus/2
        [HttpDelete("DeleteStatus{id}")]
        public async Task<ActionResult<Status>> DeleteStatus(int id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Status.Remove(status);
            await _context.SaveChangesAsync();

            return status;
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.Id == id);
        }
    }
}
