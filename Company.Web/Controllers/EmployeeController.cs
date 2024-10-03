using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Services.Employee.Dto;
using Company.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            ViewBag.Message = " Hello from Employee index";
            TempData["TextMessage"]="Hello from Employee index";
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();
            else
                employees = _employeeService.GetEmployeeByName(searchInp);
            return View(employees);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    var departments = _departmentService.GetAll();
        //    ViewBag.Departments = new SelectList(departments, "Id", "Name");
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(EmployeeDto employee)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _employeeService.Add(employee);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(employee);
        //}
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto emp)
        {

            try
            {
                emp.Department = _departmentService.GetById(emp.DepartmentId);
                if (ModelState.IsValid)
                {

                    _employeeService.Add(emp);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }

                }
                return View(emp);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepError", ex.Message);

                return View(emp);

            }
        }
    }
}
