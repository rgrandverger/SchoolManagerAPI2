
using SchoolManagerAPI2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerAPI2.Services
{
	public interface IUcenikService
	{
		Task<IEnumerable<Ucenik>> GetAllAsync();
		Task<Ucenik?> GetByIdAsync(int id);
		Task<Ucenik> AddAsync(Ucenik ucenik);
		Task<bool> UpdateAsync(int id, Ucenik ucenik);
		Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Ucenik>> GetByNameAsync(string name);
	}
}
