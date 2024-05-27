using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APBD8.Models;

namespace APBD8.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CountryController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] Country? country)
        {
            if (country == null)
            {
                return BadRequest("Country is null.");
            }

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountry), new { id = country.IdCountry }, country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] Country country)
        {
            if (id != country.IdCountry)
            {
                return BadRequest("Country ID is false!");
            }

            var countryToUpdate = await _context.Countries.FindAsync(id);
            if (countryToUpdate == null)
            {
                return NotFound("No country matches :[.");
            }

            countryToUpdate.Name = country.Name;
            
            _context.Countries.Update(countryToUpdate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound("No country matches :[");
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
