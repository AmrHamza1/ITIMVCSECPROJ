namespace ITIMVCSECPROJ.Models
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = DateTime.Now;

    }
}
