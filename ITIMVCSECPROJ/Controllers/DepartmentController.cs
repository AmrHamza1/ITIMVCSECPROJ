using ITIMVCSECPROJ.Models;
using ITIMVCSECPROJ.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITIMVCSECPROJ.Controllers
{
    public class DepartmentController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        private DepartmentBL _departmentBL;
        private InstructorBL _instructorBL;
        public DepartmentController()
        {
            _departmentBL = new DepartmentBL(_context);
            _instructorBL = new InstructorBL(_context);
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 5;
            int total = _departmentBL.GetDepartmentsCount();
            PaginatedDepartmentVM vm = new PaginatedDepartmentVM
            {
                Departments = _departmentBL.GetDepartmentsVM(page,pageSize),
                CurrentPage = page,
                PageCount = (int)Math.Ceiling((double)total / pageSize)
            };
            return View(vm);
        }
        public IActionResult Details(int id)
        {
            var department = _departmentBL.GetDepartment(id);
            return View(department);
        }
        public IActionResult Search(string name)
        {
            var departments = _departmentBL.SearchDepartments(name);
            return View(departments);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddDeptWithInsVM vm = new AddDeptWithInsVM();
            vm.Instructors = _instructorBL.GetInstructors();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Add(AddDeptWithInsVM newDept)
        {
            if(ModelState.IsValid)
            {
                Department department = new Department
                {
                    Name = newDept.DeptName,
                    ManagerId = newDept.ManagerID
                };
                _departmentBL.AddDepartment(department);
                return RedirectToAction("Index");
            }
            newDept.Instructors = _instructorBL.GetInstructors();
            return View(newDept);

        }
    }
}
