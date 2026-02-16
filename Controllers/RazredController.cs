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
    public class RazredController : ControllerBase
    {
        private readonly IRazredService _razredService;

        public RazredController(IRazredService razredService)
        {
            _razredService = razredService;
        }

        // GET: api/Razred
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Razred>>> GetRazredi4()
        {
            var razredi = await _razredService.GetAllAsync();
            return Ok(razredi);
        }

        // GET: api/Razred/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Razred>> GetRazred(int id)
        {
            var razred = await _razredService.GetByIdAsync(id);
            if (razred == null)
            {
                return NotFound();
            }
            return Ok(razred);
        }

        // PUT: api/Razred/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRazred(int id, Razred razred)
        {
            if (id != razred.Id)
            {
                return BadRequest();
            }
            var updated = await _razredService.UpdateAsync(id, razred);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Razred
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Razred>> PostRazred(Razred razred)
        {
            var created = await _razredService.AddAsync(razred);
            return CreatedAtAction("GetRazred", new { id = created.Id }, created);
        }

        // DELETE: api/Razred/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRazred(int id)
        {
            var deleted = await _razredService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        // RazredExists method removed; handled in service
    }
}
