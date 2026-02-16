using SchoolManagerAPI2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerAPI2.Services
{
    public interface IRazredService
    {
        Task<IEnumerable<Razred>> GetAllAsync();
        Task<Razred?> GetByIdAsync(int id);
        Task<Razred> AddAsync(Razred razred);
        Task<bool> UpdateAsync(int id, Razred razred);
        Task<bool> DeleteAsync(int id);
    }
}
