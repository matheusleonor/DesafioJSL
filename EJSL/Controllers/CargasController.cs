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
    public class CargasController : ControllerBase
    {
        private readonly EjslContext _context;

        [HttpGet("/Carga")]
        public IActionResult GetCargasJson()
        {
            var cargas = _context.Cargas.ToList();
            return Ok(cargas);
        }

        public CargasController(EjslContext context)
        {
            _context = context;
        }

        // GET: api/Cargas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carga>>> GetCargas()
        {
          if (_context.Cargas == null)
          {
              return NotFound();
          }
            return await _context.Cargas.ToListAsync();
        }

        // GET: api/Cargas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carga>> GetCarga(int id)
        {
          if (_context.Cargas == null)
          {
              return NotFound();
          }
            var carga = await _context.Cargas.FindAsync(id);

            if (carga == null)
            {
                return NotFound();
            }

            return carga;
        }

        // PUT: api/Cargas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarga(int id, Carga carga)
        {
            if (id != carga.Id)
            {
                return BadRequest();
            }

            _context.Entry(carga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargaExists(id))
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

        // POST: api/Cargas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carga>> PostCarga(Carga carga)
        {
          if (_context.Cargas == null)
          {
              return Problem("Entity set 'EjslContext.Cargas'  is null.");
          }
            _context.Cargas.Add(carga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarga", new { id = carga.Id }, carga);
        }

        // DELETE: api/Cargas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarga(int id)
        {
            if (_context.Cargas == null)
            {
                return NotFound();
            }
            var carga = await _context.Cargas.FindAsync(id);
            if (carga == null)
            {
                return NotFound();
            }

            _context.Cargas.Remove(carga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargaExists(int id)
        {
            return (_context.Cargas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
