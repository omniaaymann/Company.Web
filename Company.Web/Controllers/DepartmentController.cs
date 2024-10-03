using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Services.Department.Dto;
using Company_Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            //TempData.Keep("TextMessage");
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDto department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("DepartmentError", "ValidationErrors");
                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(department);
            }
            
        }


        public IActionResult Details(int? id, string viewName="Details")
        {
            var department = _departmentService.GetById(id);
            if (department == null)
            {
                return RedirectToAction("NotFound", null, "Home");
            }
            return View(viewName, department);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, DepartmentDto department)
        {
            if(department.Id != id.Value)
                return RedirectToAction("NotFound", null, "Home");
            _departmentService.Update(department);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
                return RedirectToAction("NotFoundPage", null, "Home");
            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        }

    }
}
