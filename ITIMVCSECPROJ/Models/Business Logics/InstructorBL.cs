namespace ITIMVCSECPROJ.Models
{
    public class InstructorBL
    {
        private readonly AppDbContext _context;
        public InstructorBL(AppDbContext context)
        {
            _context = context;
        }
        public List<Instructor> GetInstructors()
        {
            var instructors = _context.Instructors.Where(i=>i.IsDeleted == false).ToList();
            return instructors;
        }
        public Instructor GetInstructor(int id)
        {
            var instructor = _context.Instructors.Where(i=>i.IsDeleted == false).FirstOrDefault(i => i.Id == id);
            return instructor;
        }
        public List<Instructor> SearchInstructors(string name)
        {
            var instructors = _context.Instructors.Where(i=>i.IsDeleted == false).Where(i=>string.IsNullOrEmpty(name)||i.Name.Contains(name)).ToList();
            return instructors;
        }
        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
        }


    }
}
