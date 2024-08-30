using allianzServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace allianzServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PoliceController(AppDbContext context)
        {
            _context = context;
        }

        // POST 
        [HttpPost("Home")]
        public async Task<IActionResult> Home([FromBody] PoliceTable model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.PoliceTable.Add(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET 
        [HttpGet("Home/{id}")]
        public async Task<IActionResult> GetPolice(int id)
        {
            var police = await _context.PoliceTable.FindAsync(id);
            if (police == null)
            {
                return NotFound("Müşteri bulunamadı.");
            }
            return Ok(police);
        }



        // DELETE
        [HttpDelete("Home/{id}")]
        public async Task<IActionResult> DeletePolice(int id)
        {
            var police = await _context.PoliceTable.FindAsync(id);
            if (police == null)
            {
                return NotFound("Poliçe bulunamadı.");
            }

            try
            {
                _context.PoliceTable.Remove(police);
                await _context.SaveChangesAsync();
                return Ok("Poliçe başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}



