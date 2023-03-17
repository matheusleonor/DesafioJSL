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
    public class MotoristasController : ControllerBase
    {
        private readonly EjslContext _context;

        public MotoristasController(EjslContext context)
        {
            _context = context;
        }

        // GET: api/Motoristas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motorista>>> GetMotorista()
        {
          if (_context.Motorista == null)
          {
              return NotFound();
          }
            return await _context.Motorista.ToListAsync();
        }

        // GET: api/Motoristas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motorista>> GetMotorista(int id)
        {
          if (_context.Motorista == null)
          {
              return NotFound();
          }
            var motorista = await _context.Motorista.FindAsync(id);

            if (motorista == null)
            {
                return NotFound();
            }

            return motorista;
        }

        // PUT: api/Motoristas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorista(int id, Motorista motorista)
        {
            if (id != motorista.Id)
            {
                return BadRequest();
            }

            _context.Entry(motorista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoristaExists(id))
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

        // POST: api/Motoristas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Motorista>> PostMotorista(Motorista motorista)
        {
          if (_context.Motorista == null)
          {
              return Problem("Entity set 'EjslContext.Motorista'  is null.");
          }
            _context.Motorista.Add(motorista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotorista", new { id = motorista.Id }, motorista);
        }

        // DELETE: api/Motoristas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorista(int id)
        {
            if (_context.Motorista == null)
            {
                return NotFound();
            }
            var motorista = await _context.Motorista.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }

            _context.Motorista.Remove(motorista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotoristaExists(int id)
        {
            return (_context.Motorista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
