using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCSECPROJ.Models
{
    public class Course: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public int MaxDegree { get; set; }
        public int MinDegree { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<CourseResult> CoursesResults { get; set; } = new List<CourseResult>();
    }
}
