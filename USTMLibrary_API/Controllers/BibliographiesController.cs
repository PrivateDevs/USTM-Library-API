using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USTMLibrary_API.Data;
using USTMLibrary_API.model;

namespace USTMLibrary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographiesController : ControllerBase
    {
        private readonly USTMLibrary_APIContext _context;

        public BibliographiesController(USTMLibrary_APIContext context)
        {
            _context = context;
        }

        // GET: api/Bibliographies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bibliography>>> GetBibliography()
        {
          if (_context.Bibliography == null)
          {
              return NotFound();
          }
            return await _context.Bibliography.ToListAsync();
        }

        // GET: api/Bibliographies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bibliography>> GetBibliography(int id)
        {
          if (_context.Bibliography == null)
          {
              return NotFound();
          }
            var bibliography = await _context.Bibliography.FindAsync(id);

            if (bibliography == null)
            {
                return NotFound();
            }

            return bibliography;
        }

        // PUT: api/Bibliographies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBibliography(int id, Bibliography bibliography)
        {
            if (id != bibliography.ISBN)
            {
                return BadRequest();
            }

            _context.Entry(bibliography).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliographyExists(id))
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

        // POST: api/Bibliographies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bibliography>> PostBibliography(Bibliography bibliography)
        {
          if (_context.Bibliography == null)
          {
              return Problem("Entity set 'USTMLibrary_APIContext.Bibliography'  is null.");
          }
            _context.Bibliography.Add(bibliography);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBibliography", new { id = bibliography.ISBN }, bibliography);
        }

        // DELETE: api/Bibliographies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBibliography(int id)
        {
            if (_context.Bibliography == null)
            {
                return NotFound();
            }
            var bibliography = await _context.Bibliography.FindAsync(id);
            if (bibliography == null)
            {
                return NotFound();
            }

            _context.Bibliography.Remove(bibliography);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BibliographyExists(int id)
        {
            return (_context.Bibliography?.Any(e => e.ISBN == id)).GetValueOrDefault();
        }
    }
}
