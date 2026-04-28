namespace ITIMVCSECPROJ.Models
{
    public class CourseBL
    {
        private readonly AppDbContext _context;
        public CourseBL(AppDbContext context)
        {
            _context = context;
        }
        public List<Course> GetCourses()
        {
            var courses = _context.Courses.Where(c=>c.IsDeleted == false).ToList();
            return courses;
        }
        public Course GetCourse(int id)
        {
            var course = _context.Courses.Where(d => d.IsDeleted == false).FirstOrDefault();
            return course;
        }
        public List<Course> SearchCourses(string name)
        {
            var courses = _context.Courses.Where(d => d.IsDeleted == false).Where(i => string.IsNullOrEmpty(name) || i.Name.Contains(name)).ToList();
            return courses;
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
        public void DeleteCourse(int id)
        {
            var course = GetCourse(id);
            course.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
