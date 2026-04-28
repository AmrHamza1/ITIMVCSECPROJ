using ITIMVCSECPROJ.Helpers;
using ITIMVCSECPROJ.Models;
using ITIMVCSECPROJ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ITIMVCSECPROJ.Controllers
{
    public class InstructorController : Controller
    {
        private AppDbContext context = new AppDbContext();
        private InstructorBL _instructorBL;
        private DepartmentBL _departmentBL;
        private CourseBL _courseBL;

        public InstructorController()
        {
            _instructorBL = new InstructorBL(context);
            _courseBL = new CourseBL(context);
            _departmentBL = new DepartmentBL(context); 
        }

        public IActionResult Index()
        {
            var instructors = _instructorBL.GetInstructors();
            return View(instructors);
        }
        public IActionResult Details(int id)
        {
            var instructor = _instructorBL.GetInstructor(id);
            return View(instructor);
        }
        public IActionResult Search(string name)
        {
            var instructors = _instructorBL.SearchInstructors(name);
            return View("Index", instructors);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddInsWithCrsDeptVM ViewModel = new AddInsWithCrsDeptVM
            {
                Departments = _departmentBL.GetDepartments(),
                Courses = _courseBL.GetCourses()
            };
            return View(ViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddInsWithCrsDeptVM newinstructor)
        {
            if(ModelState.IsValid)
            {
                Instructor i = new Instructor
                {
                    Name = newinstructor.Name,
                    Address = newinstructor.Address,
                    Salary = newinstructor.Salary,
                    DepartmentId = newinstructor.DepartmentId,
                    CourseId = newinstructor.CourseId,
                    ImageUrl = ImageFileHelper.imageUpload(newinstructor.Image, "Instructor-Images")
                };
                _instructorBL.AddInstructor(i);
                return RedirectToAction("Index");
            }
            newinstructor.Departments = _departmentBL.GetDepartments();
            newinstructor.Courses = _courseBL.GetCourses();
            return View(newinstructor);
        }
    }
}
