using SchoolManagerAPI2.Models;
using SchoolManagerAPI2.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerAPI2.Services
{
    public class RazredService : IRazredService
    {
        private readonly AppDbContext _context;

        public RazredService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Razred>> GetAllAsync()
        {
            return await _context.Razredi4.ToListAsync();
        }

        public async Task<Razred?> GetByIdAsync(int id)
        {
            return await _context.Razredi4.FindAsync(id);
        }

        public async Task<Razred> AddAsync(Razred razred)
        {
            _context.Razredi4.Add(razred);
            await _context.SaveChangesAsync();
            return razred;
        }

        public async Task<bool> UpdateAsync(int id, Razred razred)
        {
            if (id != razred.Id)
                return false;
            _context.Entry(razred).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Razredi4.AnyAsync(e => e.Id == id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var razred = await _context.Razredi4.FindAsync(id);
            if (razred == null)
                return false;
            _context.Razredi4.Remove(razred);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
