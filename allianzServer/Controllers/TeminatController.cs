using allianzServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace allianzServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeminatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeminatController(AppDbContext context)
        {
            _context = context;
        }


        // POST 
        [HttpPost("Home")]
        public async Task<IActionResult> Home([FromBody] TeminatTable model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.TeminatTable.Add(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        // GET 
        [HttpGet("Home")]
        public async Task<IActionResult> GetTeminat()
        {
            var teminatList = await _context.TeminatTable.ToListAsync();
            if (teminatList == null || !teminatList.Any())
            {
                return NotFound("Teminat bulunamadı.");
            }
            return Ok(teminatList);
        }

    }
}