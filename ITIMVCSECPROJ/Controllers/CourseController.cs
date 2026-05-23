using ITIMVCSECPROJ.Models;
using ITIMVCSECPROJ.ViewModels;
using ITIMVCSECPROJ.ViewModels.CourseViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITIMVCSECPROJ.Controllers
{
    public class CourseController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        private CourseBL _courseBl;
        private DepartmentBL _departmentBL;
        public CourseController()
        {
            _departmentBL = new DepartmentBL(_context);
            _courseBl = new CourseBL(_context);
        }
        public IActionResult Index(int page = 1)
        {
            var Courses = _courseBl.GetCourses(page, 10);
            return View(Courses);
        }
        public IActionResult Search(string searched, int page = 1)
        {
            var Courses = _courseBl.GetCourses(page, 10, searched);
            return View("Index", Courses);
        }
        public IActionResult Detail(int id)
        {
            CourseDetailedVM VM = _courseBl.GetCourse(id);
            if (VM == null)
                return NotFound();
            return View(VM);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var departments = _departmentBL.GetAllDepartments();
            var VM = new CourseAddVM
            {
                Departments = departments
            };
            return View(VM);
        }
        [HttpPost]
        public IActionResult Add(CourseAddVM newCourse)
        {
            if (ModelState.IsValid)
            {

                bool flag = _courseBl.AddCourse(newCourse);
                if(!flag)
                    return NotFound();
                return RedirectToAction("Index");
            }
            newCourse.Departments = _departmentBL.GetAllDepartments();
            return View(newCourse);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vm = _courseBl.GetCourseForEdit(id);
            if (vm == null)
                return NotFound();
            vm.Departments = _departmentBL.GetAllDepartments();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CourseEditVM newCourse)
        {
            if (ModelState.IsValid)
            {
                bool flag = _courseBl.EditCourse(newCourse);
                if(!flag)
                    return NotFound();
                return RedirectToAction("Index");
            }
            newCourse.Departments = _departmentBL.GetAllDepartments();
            return View(newCourse);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _courseBl.DeleteCourse(id);
            if (!result)
                return NotFound();
            return RedirectToAction("Index");
        }
    }
}
