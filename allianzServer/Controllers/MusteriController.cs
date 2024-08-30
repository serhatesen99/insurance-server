using allianzServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace allianzServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusteriController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MusteriController(AppDbContext context)
        {
            _context = context;
        }

        // POST 
        [HttpPost("Home")]
        public async Task<IActionResult> Home([FromBody] MusteriTable model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.MusteriTable.Add(model);
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
        public async Task<IActionResult> GetMusteri(int id)
        {
            var musteri = await _context.MusteriTable.FindAsync(id);
            if (musteri == null)
            {
                return NotFound("Müþteri bulunamadý.");
            }
            return Ok(musteri);
        }

        // DELETE
        [HttpDelete("Home/{id}")]
        public async Task<IActionResult> DeleteMusteri(int id)
        {
            var musteri = await _context.MusteriTable.FindAsync(id);
            if (musteri == null)
            {
                return NotFound("Müþteri bulunamadý.");
            }

            try
            {
                _context.MusteriTable.Remove(musteri);
                await _context.SaveChangesAsync();
                return Ok("Müþteri baþarýyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

