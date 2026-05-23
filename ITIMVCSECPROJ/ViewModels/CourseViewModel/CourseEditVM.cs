using ITIMVCSECPROJ.ViewModels.DepartmentViewModel;
using System.ComponentModel.DataAnnotations;

namespace ITIMVCSECPROJ.ViewModels.CourseViewModel
{
    public class CourseEditVM
    {
        public int CourseID { get; set; }

        [MaxLength(30, ErrorMessage = "Course name cannot exceed 30 characters.")]
        [MinLength(3, ErrorMessage = "Course name must be at least 3 characters long.")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Course name can only contain alphanumeric characters and spaces.")]
        public string CourseName { get; set; }

        [Range(1, 3, ErrorMessage = "Course hours must be between 1 and 3.")]
        public int CourseHours { get; set; }
        [Range(1, 100, ErrorMessage = "Course maximum degree must be between 1 and 100.")]
        public int CourseMaxDegree { get; set; }
        [Range(1, 50, ErrorMessage = "Course minimum degree must be between 1 and 50.")]
        public int CourseMinDegree { get; set; }
        public int DepartmentId { get; set; }
        public List<DepartmentVM> Departments { get; set; }
    }
}
