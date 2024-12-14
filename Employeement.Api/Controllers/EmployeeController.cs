using AutoMapper;
using Employeement.Api.Dtos;
using Employeement.Api.Interfaces;
using Employeement.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employeement.Api.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployerRepository employerRepository;
        private readonly IMapper mapper;

        public EmployeeController(IEmployerRepository employerRepository, IMapper mapper)
        {
            this.employerRepository = employerRepository;
            this.mapper = mapper;
        }

        //CREATE Operation
        /// <summary>
        /// Create a new employee.
        /// </summary>
        /// <param name="addEmployeeDto"> The employee data to add.</param>
        /// <returns> The newly created employee object.</returns>
        [HttpPost]
        public async Task<IActionResult> AddEmlpoyer([FromBody] EmployeeDto addEmployeeDto)
        {
            /*var addEmployer = new Employee
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone
            };*/
            if (addEmployeeDto == null)
            {
                return BadRequest("Employee data is required.");
            }

            var addEmployer = mapper.Map<Employee> (addEmployeeDto);
            await employerRepository.AddEmployeeAsync(addEmployer);
            var CreatedEmployeeDto = mapper.Map<EmployeeDto> (addEmployer);

            return Ok(CreatedEmployeeDto);
        }

        //READ Operations
        /// <summary>
        /// Return all the employees from the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var allEmployees = await employerRepository.GetAllEmployees();

            return Ok(allEmployees);
        }


        /// <summary>
        /// Return an employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            var employee = await employerRepository.GetEmployeeByIDAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        /// <summary>
        /// Search an employee by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/{name}")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            var employee = await employerRepository.GetEmployeeByNameAsync(name);

            if (employee == null || !employee.Any())
            {
                return NotFound();
            }

            return Ok(employee);
        }

        //Update Operation
        /// <summary>
        /// Update an existing employee.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateEmployee"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto updateEmployeeDto)
        {
            var existingEmployee = await employerRepository.GetEmployeeByIDAsync(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            /*employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;*/

            mapper.Map(updateEmployeeDto, existingEmployee);
            await employerRepository.UpdateEmployeeAsync(existingEmployee);
            var updatedEmployeeDto  = mapper.Map<EmployeeDto>(existingEmployee);

            return Ok(updatedEmployeeDto);
        }

        //Delete Operation
        /// <summary>
        /// Delete an existing employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await employerRepository.GetEmployeeByIDAsync(id);

            if (employee == null)
            {
                return NotFound(id);
            }

            await employerRepository.DeleteEmployeeAsync(employee);

            return Ok();
        }

    }
}
