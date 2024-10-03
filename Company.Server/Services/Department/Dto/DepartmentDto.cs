using Company.Service.Services.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services.Department.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}
