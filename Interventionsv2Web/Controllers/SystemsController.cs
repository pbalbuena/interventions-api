using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Interventionsv2Web.Data;
using Interventionsv2Web.Models;
//using System.Data.SQLite;
using System.Data;
using System.Data.Entity.Core.EntityClient;

namespace Interventionsv2Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemsController : ControllerBase
    {
        private readonly InterventionsContext _context;

        public SystemsController(InterventionsContext context)
        {
            _context = context;
        }

        // GET: api/Systems
        [HttpGet]
        public IEnumerable<Interventionsv2Web.Models.System> GetSystems()
        {
            return _context.Systems;
        }

        // GET: api/Systems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSystem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*
            using (var con = new EntityConnection("DefaultConnection"))
            {
                con.Open();
                EntityCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT VALUE st FROM system as st where st.Id_system='"+id+"'";
                Task<IActionResult> dict = new Dictionary<int, string>();
                using (EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
                {
                    while (rdr.Read())
                    {
                        int a = rdr.GetInt32(0);
                        var b = rdr.GetString(1);
                        dict.Add(a, b);
                    }
                }
            }
            */
            // var system= await _context.Systems.Where(s => s.id_system == id).SingleAsync();           
            // var system = _context.Systems.FromSql("SELECT * FROM system WHERE Id_system={0}", id).ToList();
            var system = await _context.Systems.FindAsync(id);
            //var system = (from s in _context.Systems where s.Idsystem == id select s).FirstOrDefault();

            if (system == null)
            {
                return NotFound();
            }

            return Ok(system);
        }

        // PUT: api/Systems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystem([FromRoute] int id, [FromBody] Interventionsv2Web.Models.System system)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*
            if (id != system.Idsystem)
            {
                return BadRequest();
            }
            */
            system.Idsystem = id;
            //_context.Systems.FromSql("UPDATE system SET Name={0} WHERE Id_system={1}", system.Name, id);
            _context.Update(system);
            _context.Entry(system).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // POST: api/Systems
        [HttpPost]
        public async Task<IActionResult> PostSystem([FromBody] Interventionsv2Web.Models.System system)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Systems.Add(system);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystem", new { id = system.Idsystem }, system);
        }

        // DELETE: api/Systems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var system = await _context.Systems.FindAsync(id);
            if (system == null)
            {
                return NotFound();
            }

            _context.Systems.Remove(system);
            await _context.SaveChangesAsync();

            return Ok(system);
        }

        private bool SystemExists(int id)
        {
            return _context.Systems.Any(e => e.Idsystem == id);
        }
    }
}