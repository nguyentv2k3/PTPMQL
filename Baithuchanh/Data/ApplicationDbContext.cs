using Microsoft.EntityFrameworkCore;
using Baithuchanh.Models;
namespace Baithuchanh.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Person> Person { get; set; }
        public DbSet<Baithuchanh.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Baithuchanh.Models.HeThongPhanPhoi> HeThongPhanPhoi { get; set; } = default!;
        public DbSet<Baithuchanh.Models.DaiLy> DaiLy { get; set; } = default!;
    }
    
}