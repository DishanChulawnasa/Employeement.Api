using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employeement.Api.Controllers;
using Employeement.Api.Data;
using Employeement.Api.Dtos;
using Employeement.Api.Models;

namespace Employeement.Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //CREATE Operation
        //Add new employees to the database
        [HttpPost]
        public IActionResult AddEmlpoyer(EmployeeDto addEmployeeDto)
        {
            var addEmployer = new Employee
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone
            };

            dbContext.Add(addEmployer);
            dbContext.SaveChanges();

            return Ok(addEmployer);
        }

        //READ Operations
        //return all the employees from the database.
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        
        //return employee by id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeByID(int id) 
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
               return NotFound();
            }

            return Ok(employee);
        }

        
        //Update Operation
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeDto updateEmployee)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployee.Name;
            employee.Email = updateEmployee.Email;
            employee.Phone = updateEmployee.Phone;

            dbContext.SaveChanges();

            return Ok(updateEmployee);
        }

        //Delete Operation
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound(id);
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();    

            return Ok();
        }
        
    }
}
