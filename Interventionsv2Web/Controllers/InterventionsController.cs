using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Interventionsv2Web.Data;
using Interventionsv2Web.Models;

namespace Interventionsv2Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly InterventionsContext _context;

        public InterventionsController(InterventionsContext context)
        {
            _context = context;
        }

        // GET: api/Interventions
        [HttpGet]
        public IEnumerable<Intervention> GetIntervention()
        {
            return _context.Intervention;
        }

        public async Task<IActionResult> GetInterventionTest(DateTime date)
        {
            var intervention = await (from s in _context.Intervention where s.Date == date select s).ToListAsync();
            return Ok(intervention);
        }

        // GET: api/Interventions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIntervention([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var intervention = await _context.Intervention.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return Ok(intervention);
        }

        // PUT: api/Interventions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntervention([FromRoute] int id, [FromBody] Intervention intervention)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != intervention.Idintervention)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
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

        // POST: api/Interventions
        [HttpPost]
        public async Task<IActionResult> PostIntervention([FromBody] Intervention intervention)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Intervention.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntervention", new { id = intervention.Idintervention }, intervention);
        }

        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntervention([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var intervention = await _context.Intervention.FindAsync(id);
            if (intervention == null)
            {
                return NotFound();
            }

            _context.Intervention.Remove(intervention);
            await _context.SaveChangesAsync();

            return Ok(intervention);
        }

        private bool InterventionExists(int id)
        {
            return _context.Intervention.Any(e => e.Idintervention == id);
        }
    }
}