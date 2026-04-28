namespace ITIMVCSECPROJ.ViewModels
{
    using ITIMVCSECPROJ.Models;
    public class AddInsWithCrsDeptVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IFormFile Image { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
