using ITIMVCSECPROJ.Models;

namespace ITIMVCSECPROJ.ViewModels
{
    public class PaginatedDepartmentVM
    {
        public List<Department> Departments { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < PageCount;
    }
}
