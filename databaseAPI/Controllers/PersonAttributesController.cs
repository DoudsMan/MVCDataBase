using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using databaseAPI.Model;

namespace databaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonAttributesController : ControllerBase
    {
        private readonly DBcsc484Context _context;

        public PersonAttributesController(DBcsc484Context context)
        {
            _context = context;
        }

        // GET: api/PersonAttributes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonAttributes>>> GetPersonAttributes()
        {
            return await _context.PersonAttributes.ToListAsync();
        }

        // GET: api/PersonAttributes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonAttributes>> GetPersonAttributes(int id)
        {
            var personAttributes = await _context.PersonAttributes.FindAsync(id);

            if (personAttributes == null)
            {
                return NotFound();
            }

            return personAttributes;
        }

        // PUT: api/PersonAttributes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonAttributes(int id, PersonAttributes personAttributes)
        {
            if (id != personAttributes.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(personAttributes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonAttributesExists(id))
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

        // POST: api/PersonAttributes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PersonAttributes>> PostPersonAttributes(PersonAttributes personAttributes)
        {
            _context.PersonAttributes.Add(personAttributes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonAttributesExists(personAttributes.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonAttributes", new { id = personAttributes.PersonId }, personAttributes);
        }

        // DELETE: api/PersonAttributes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonAttributes>> DeletePersonAttributes(int id)
        {
            var personAttributes = await _context.PersonAttributes.FindAsync(id);
            if (personAttributes == null)
            {
                return NotFound();
            }

            _context.PersonAttributes.Remove(personAttributes);
            await _context.SaveChangesAsync();

            return personAttributes;
        }

        private bool PersonAttributesExists(int id)
        {
            return _context.PersonAttributes.Any(e => e.PersonId == id);
        }
    }
}
