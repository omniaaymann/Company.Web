using AutoMapper;
using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Services.Department.Dto;
using Company_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public void Add(DepartmentDto departmentDTO)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreatedDate = DateTime.Now,
            //};
            var mappedDepartment = _mapper.Map<Data.Models.Department>(departmentDTO);
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Data.Models.Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var mappedDepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments); 
            return mappedDepartments;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department is null)
                return null;
            var mappedDepartment = _mapper.Map<DepartmentDto>(department);
            return mappedDepartment;
        }

        public void Update(DepartmentDto departmentDto)
        {
            //var dept = GetById(department.Id);
            //if(dept.Name != department.Name)
            //{
            //    if (GetAll().Any(x => x.Name == department.Name))
            //        throw new Exception("Duplicate department");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;
            //_unitOfWork.DepartmentRepository.Update(department);
            //_unitOfWork.Complete();

        }
    }
}
