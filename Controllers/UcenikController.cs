        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagerAPI2.Data;
using SchoolManagerAPI2.Models;
using SchoolManagerAPI2.Services;

namespace SchoolManagerAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UcenikController : ControllerBase
    {

        private readonly IUcenikService _ucenikService;

        public UcenikController(IUcenikService ucenikService)
        {
            _ucenikService = ucenikService;
        }

        // GET: api/Ucenik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ucenik>>> GetUcenici4()
        {
            var ucenici = await _ucenikService.GetAllAsync();
            return Ok(ucenici);
        }

        // GET: api/Ucenik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ucenik>> GetUcenik(int id)
        {
            var ucenik = await _ucenikService.GetByIdAsync(id);
            if (ucenik == null)
            {
                return NotFound();
            }
            return Ok(ucenik);
        }

        // PUT: api/Ucenik/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUcenik(int id, Ucenik ucenik)
        {
            if (id != ucenik.Id)
            {
                return BadRequest();
            }
            var updated = await _ucenikService.UpdateAsync(id, ucenik);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Ucenik
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ucenik>> PostUcenik(Ucenik ucenik)
        {
            var created = await _ucenikService.AddAsync(ucenik);
            return CreatedAtAction("GetUcenik", new { id = created.Id }, created);
        }

        // DELETE: api/Ucenik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUcenik(int id)
        {
            var deleted = await _ucenikService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        // GET: api/Ucenik/name/{name}
        [HttpGet("/{name}")]
        public async Task<ActionResult<IEnumerable<Ucenik>>> GetUceniciByName(string name)
        {
            var filtered = await _ucenikService.GetByNameAsync(name);
            return Ok(filtered);
        }

        // UcenikExists method removed; handled in service
    }
}
