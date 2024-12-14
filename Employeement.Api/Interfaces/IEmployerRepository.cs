using Employeement.Api.Dtos;
using Employeement.Api.Models;

namespace Employeement.Api.Interfaces
{
    public interface IEmployerRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task AddEmployeeAsync(Employee addEmployer);
        Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string name);
        Task<Employee?> GetEmployeeByIDAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employee);
    }
}
