using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCSECPROJ.Models
{
    public class Trainee: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Grade { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<CourseResult> CoursesResults { get; set; } = new List<CourseResult>();

    }
}
