using Employeement.Api.Data;
using Employeement.Api.Dtos;
using Employeement.Api.Interfaces;
using Employeement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Employeement.Api.Repositories
{
    public class EmployeeRepository : IEmployerRepository
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
           return await dbContext.Set<Employee>().ToListAsync();
        }

        public async Task AddEmployeeAsync(Employee addEmployer)
        {
            dbContext.Add(addEmployer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string name)
        {
            return await dbContext.Employees
                                  .ToListAsync()
                                  .ContinueWith(task => task.Result
                                  .Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                                  .ToList());
        }

        public async Task<Employee?> GetEmployeeByIDAsync(int id)
        {
            return await dbContext.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            dbContext.Employees.Remove(employee);
            await dbContext.SaveChangesAsync();
        }
      

    }
}
