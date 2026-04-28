using ITIMVCSECPROJ.Models;

namespace ITIMVCSECPROJ.ViewModels
{
    public class AddDeptWithInsVM
    {
        public string DeptName { get; set; }
        public int? ManagerID { get; set; }
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
