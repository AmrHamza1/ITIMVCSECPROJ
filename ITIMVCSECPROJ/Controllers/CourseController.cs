using ITIMVCSECPROJ.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIMVCSECPROJ.Controllers
{
    public class CourseController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        private CourseBL _coursebl;
        public CourseController()
        {
            _coursebl = new CourseBL(_context);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
