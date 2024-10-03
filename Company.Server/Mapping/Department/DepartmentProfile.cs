using AutoMapper;
using Company.Data.Models;
using Company.Service.Services.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Mapping.Department
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Data.Models.Department, DepartmentDto>().ReverseMap();
        }
    }
}
