using Microsoft.EntityFrameworkCore;
using SchoolManagerAPI2.Models;

namespace SchoolManagerAPI2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ucenik> Ucenici4 { get; set; }
        public DbSet<Razred> Razredi4 { get; set; }
    }
}