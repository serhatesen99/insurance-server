using allianzServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace allianzServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliceTeminatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PoliceTeminatController(AppDbContext context)
        {
            _context = context;
        }

        // POST 
        [HttpPost("Home")]
        public async Task<IActionResult> Home([FromBody] PoliceTeminatTable model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.PoliceTeminatTable.Add(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

 
    }
}