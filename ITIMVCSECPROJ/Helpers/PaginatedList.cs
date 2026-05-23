namespace ITIMVCSECPROJ.Helpers
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PaginatedList(List<T> values, int count, int page, int pageSize )
        {
            CurrentPage = page;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = values;
        }
    }
}
