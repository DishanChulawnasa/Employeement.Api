using AutoMapper;
using Employeement.Api.Dtos;
using Employeement.Api.Models;

namespace Employeement.Api.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
