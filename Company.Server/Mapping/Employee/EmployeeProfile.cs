using AutoMapper;
using Company.Service.Services.Employee.Dto;

namespace Company.Service.Mapping.Employee
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Data.Models.Employee, EmployeeDto>().ReverseMap();
        }
    }
}
