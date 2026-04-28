namespace ITIMVCSECPROJ.Models
{
    public class DepartmentBL
    {
        private readonly AppDbContext _context;
        public DepartmentBL(AppDbContext context)
        {
            _context = context;
        }
        public List<Department> GetDepartments()
        {
            var departments = _context.Departments.Where(d => d.IsDeleted == false).ToList();
            return departments;
        }
        public List<Department> GetDepartmentsVM(int page,int pageSize)
        {
            var departments = _context.Departments
                .Where(d=>d.IsDeleted == false)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList();
            return departments;
        }
        public int GetDepartmentsCount()
        {
            int count = _context.Departments.Where(d=>d.IsDeleted == false).Count();
            return count;
        }
        public Department GetDepartment(int id)
        {
            var department = _context.Departments.Where(d =>d.IsDeleted == false).FirstOrDefault();
            return department;
        }
        public List<Department> SearchDepartments(string name)
        {
            var departments = _context.Departments.Where(d =>d.IsDeleted == false).Where(i => string.IsNullOrEmpty(name) || i.Name.Contains(name)).ToList();
            return departments;
        }
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
        public void DeleteDepartment(int id)
        {
            var department = GetDepartment(id);
            department.IsDeleted = true;
            _context.SaveChanges();
        }


    }
}
