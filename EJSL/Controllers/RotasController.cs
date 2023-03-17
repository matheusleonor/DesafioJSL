using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EJSL.Models;

namespace EJSL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotasController : ControllerBase
    {
        private readonly EjslContext _context;

        public RotasController(EjslContext context)
        {
            _context = context;
        }

        // GET: api/Rotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rota>>> GetRota()
        {
          if (_context.Rota == null)
          {
              return NotFound();
          }
            return await _context.Rota.ToListAsync();
        }

        // GET: api/Rotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rota>> GetRota(int id)
        {
          if (_context.Rota == null)
          {
              return NotFound();
          }
            var rota = await _context.Rota.FindAsync(id);

            if (rota == null)
            {
                return NotFound();
            }

            return rota;
        }

        // PUT: api/Rotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRota(int id, Rota rota)
        {
            if (id != rota.Id)
            {
                return BadRequest();
            }

            _context.Entry(rota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaExists(id))
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

        // POST: api/Rotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rota>> PostRota(Rota rota)
        {
          if (_context.Rota == null)
          {
              return Problem("Entity set 'EjslContext.Rota'  is null.");
          }
            _context.Rota.Add(rota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRota", new { id = rota.Id }, rota);
        }

        // DELETE: api/Rotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRota(int id)
        {
            if (_context.Rota == null)
            {
                return NotFound();
            }
            var rota = await _context.Rota.FindAsync(id);
            if (rota == null)
            {
                return NotFound();
            }

            _context.Rota.Remove(rota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotaExists(int id)
        {
            return (_context.Rota?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
