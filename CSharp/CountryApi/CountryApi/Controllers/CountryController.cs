using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CountryApi.Models;

namespace CountryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryContext _context;

        public CountryController(CountryContext context)
        {
            _context = context;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            List<Country> result = new List<Country>();
            try
            {
                result = await _context.Countries
                    .Include(c => c.FunFacts)
                    .ToListAsync();
            }
            catch
            {

            }
            return result;
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            Country country = null;
            try
            {
                country = await _context.Countries
                    .Include(c => c.FunFacts)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (country == null)
                    return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }

            return country;
        }

        // POST: api/Country/5 
        [HttpPost]
        public async Task<ActionResult> PostFact(int id, string fact)
        {
            try
            {
                if (FactExists(fact, id))
                    return StatusCode(409);

                Country country = await _context.Countries
                    .Include(c => c.FunFacts)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (country == null)
                    return NotFound();

                await _context.FunFacts.AddAsync(new FunFact(fact, country));

                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok();
        }

        // POST: api/Country/5 
        [HttpDelete]
        public async Task<ActionResult> DeleteFact(int id)
        {
            try
            {
                FunFact funFact = await _context.FunFacts.FindAsync(id);

                if (funFact == null)
                    return NotFound();

                _context.FunFacts.Remove(funFact);

                await _context.SaveChangesAsync();
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok();
        }

        private bool FactExists(string fact, int id)
            => _context.FunFacts.Any(f => f.Fact == fact && f.Country != null && f.Country.Id == id);
    }
}
