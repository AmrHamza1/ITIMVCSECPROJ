using System.ComponentModel.DataAnnotations.Schema;

namespace ITIMVCSECPROJ.Models
{
    public class Department: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public Instructor Manager { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
    }
}
