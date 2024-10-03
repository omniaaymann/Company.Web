using AutoMapper;
using Company.Data.Models;
using Company.Service.Helper;
using Company.Service.Interfaces;
using Company.Service.Services.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public void Add(EmployeeDto employeeDto)
        {
            //Data.Models.Employee employee = new Data.Models.Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    Name = employeeDto.Name, 
            //    PhoneNumber = employeeDto.PhoneNumber,
            //};
            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");
            Data.Models.Employee employee = _mapper.Map<Data.Models.Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Data.Models.Employee employee = new Data.Models.Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //};
            Data.Models.Employee employee = _mapper.Map<Data.Models.Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {

            var employees = _unitOfWork.EmployeeRepository.GetAll();
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Address = x.Address,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Id = x.Id,
            //    Age = x.Age,
            //    CreatedDate = x.CreatedDate,
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee is null)
                return null;
            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    HiringDate = employee.HiringDate,
            //    ImageUrl = employee.ImageUrl,
            //    Name = employee.Name,
            //    PhoneNumber = employee.PhoneNumber,
            //    Id = employee.Id
            //};
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public void Update(EmployeeDto employeeDto)
        {
            //var emp = GetById(employeeDto.Id);
            //if (emp.Name != employeeDto.Name)
            //{
            //    if (GetAll().Any(x => x.Name == employeeDto.Name))
            //        throw new Exception("Duplicate employee");
            //}
            //emp.Name = employeeDto.Name;
            //emp.Age = employeeDto.Age;
            //_unitOfWork.EmployeeRepository.Update(employeeDto);
            //_unitOfWork.Complete();

        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Address = x.Address,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Id = x.Id,
            //    Age = x.Age,
            //    CreatedDate = x.CreatedDate,
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }
    }
}
