﻿using System;
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
    public class ViagemsController : ControllerBase
    {
        private readonly EjslContext _context;

        public ViagemsController(EjslContext context)
        {
            _context = context;
        }

        // GET: api/Viagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viagem>>> GetViagems()
        {
          if (_context.Viagems == null)
          {
              return NotFound();
          }
            return await _context.Viagems.ToListAsync();
        }

        // GET: api/Viagems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viagem>> GetViagem(int id)
        {
          if (_context.Viagems == null)
          {
              return NotFound();
          }
            var viagem = await _context.Viagems.FindAsync(id);

            if (viagem == null)
            {
                return NotFound();
            }

            return viagem;
        }

        // PUT: api/Viagems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViagem(int id, Viagem viagem)
        {
            if (id != viagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(viagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemExists(id))
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

        // POST: api/Viagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Viagem>> PostViagem(Viagem viagem)
        {
          if (_context.Viagems == null)
          {
              return Problem("Entity set 'EjslContext.Viagems'  is null.");
          }
            _context.Viagems.Add(viagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViagem", new { id = viagem.Id }, viagem);
        }

        // DELETE: api/Viagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViagem(int id)
        {
            if (_context.Viagems == null)
            {
                return NotFound();
            }
            var viagem = await _context.Viagems.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }

            _context.Viagems.Remove(viagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViagemExists(int id)
        {
            return (_context.Viagems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
