using SchoolManagerAPI2.Models;
using SchoolManagerAPI2.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerAPI2.Services
{
    public class UcenikService : IUcenikService
    {
        private readonly AppDbContext _context;

        public UcenikService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ucenik>> GetAllAsync()
        {
            return await _context.Ucenici4.ToListAsync();
        }

        public async Task<Ucenik?> GetByIdAsync(int id)
        {
            return await _context.Ucenici4.FindAsync(id);
        }

        public async Task<Ucenik> AddAsync(Ucenik ucenik)
        {
            _context.Ucenici4.Add(ucenik);
            await _context.SaveChangesAsync();
            return ucenik;
        }

        public async Task<bool> UpdateAsync(int id, Ucenik ucenik)
        {
            if (id != ucenik.Id)
                return false;
            _context.Entry(ucenik).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Ucenici4.AnyAsync(e => e.Id == id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ucenik = await _context.Ucenici4.FindAsync(id);
            if (ucenik == null)
                return false;
            _context.Ucenici4.Remove(ucenik);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Ucenik>> GetByNameAsync(string name)
        {
            return await _context.Ucenici4
                .Where(u => u.Ime.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }
    }
}
