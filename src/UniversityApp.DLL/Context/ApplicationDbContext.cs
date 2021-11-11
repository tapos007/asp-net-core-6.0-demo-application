using Microsoft.EntityFrameworkCore;
using UniversityApp.DLL.Models;

namespace UniversityApp.DLL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Department> Departments { get; set; }
    }
}

