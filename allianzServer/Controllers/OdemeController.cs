using allianzServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace allianzServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OdemeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OdemeController(AppDbContext context)
        {
            _context = context;
        }

        // POST 
        [HttpPost("Home")]
        public async Task<IActionResult> Home([FromBody] OdemeTable model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.OdemeTable.Add(model);
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
        public async Task<IActionResult> GetOdeme(int id)
        {
            var odeme = await _context.OdemeTable.FindAsync(id);
            if (odeme == null)
            {
                return NotFound("Müşteri bulunamadı.");
            }
            return Ok(odeme);
        }
    }
}

