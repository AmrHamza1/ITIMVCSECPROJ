using ITIMVCSECPROJ.Helpers;
using ITIMVCSECPROJ.ViewModels.CourseViewModel;
using Microsoft.EntityFrameworkCore;

namespace ITIMVCSECPROJ.Models
{
    public class CourseBL
    {
        private readonly AppDbContext _context;
        public CourseBL(AppDbContext context)
        {
            _context = context;
        }
        public List<CourseVM> GetAllCourses()
        {
            var query = _context.Courses
                .Where(c => !c.IsDeleted)
                .AsNoTracking()
                .Select(c => new CourseVM()
                {
                    CourseID = c.Id,
                    CourseName = c.Name
                }).ToList();
            return query;
        }
        public PaginatedList<CourseVM> GetCourses(int page, int pageSize, string search = null)
        {
            var query = _context.Courses
                .Where(c => !c.IsDeleted)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            int count = query.Count();

            var items = query
                .Select(c => new CourseVM
                {
                    CourseID = c.Id,
                    CourseName = c.Name,
                    DepartmentName = c.Department.Name
                })
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            return new PaginatedList<CourseVM>(items, count, page, pageSize);

        }


        public CourseDetailedVM GetCourse(int id)
        {
            var course = _context.Courses
                .Where(c => c.Id == id && !c.IsDeleted)
                .AsNoTracking()
                .Select(c => new CourseDetailedVM
                {
                    CourseName = c.Name,
                    CourseHours = c.CreditHours,
                    CourseMaxDegree = c.MaxDegree,
                    CourseMinDegree = c.MinDegree,
                    DepartmentName = c.Department.Name
                })
                .FirstOrDefault();
            return course;
        }

        public bool AddCourse(CourseAddVM course)
        {
            if (course == null)
                return false;
            Course newCourse = new Course
            {
                Name = course.CourseName,
                CreditHours = course.CourseHours,
                MaxDegree = course.CourseMaxDegree,
                MinDegree = course.CourseMinDegree,
                DepartmentId = course.DepartmentId
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return true;
        }
        public CourseEditVM GetCourseForEdit(int id)
        {
            var course = _context.Courses
                .Where(c => c.Id == id && !c.IsDeleted)
                .AsNoTracking()
                .Select(c => new CourseEditVM
                {
                    CourseID = c.Id,
                    CourseName = c.Name,
                    CourseHours = c.CreditHours,
                    CourseMaxDegree = c.MaxDegree,
                    CourseMinDegree = c.MinDegree,
                    DepartmentId = c.DepartmentId
                }).FirstOrDefault();
            return course;

        }
        public bool EditCourse(CourseEditVM model)
        {
             var course = _context.Courses
            .FirstOrDefault(c => c.Id == model.CourseID && !c.IsDeleted);
            if (course == null) return false;

            course.Name = model.CourseName;
            course.CreditHours = model.CourseHours;
            course.MaxDegree = model.CourseMaxDegree;
            course.MinDegree = model.CourseMinDegree;
            course.DepartmentId = model.DepartmentId;
            _context.SaveChanges();
            return true;
        }
      

        public bool DeleteCourse(int id)
        {
            Course course = _context.Courses.FirstOrDefault(c => c.Id == id && !c.IsDeleted);
            if (course == null)
                return false;
            course.IsDeleted = true;
            _context.SaveChanges();
            return true;
        }


       
    }
}
