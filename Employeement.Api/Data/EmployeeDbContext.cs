using Employeement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Employeement.Api.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
