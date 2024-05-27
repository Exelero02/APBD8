using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace APBD8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ClientController(MyDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var client = await _context.Clients.Include(c => 
            c.ClientTrips).FirstOrDefaultAsync(c => c.IdClient == idClient);

            if (client == null)
            {
                return NotFound(new { Message = "No client matches with the parameters :[" });
            }

            if (client.ClientTrips.Any())
            {
                return BadRequest(new { Message = "Client assigned for trips and cannot be deleted!" });
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}