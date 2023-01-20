namespace HealthyLife.ViewModels
{
    public class PageViewModel
    {
        public int FirstPage { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            FirstPage = 1;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public bool HasFirstPage => (PageNumber == FirstPage);
        public bool HasPreviousPage => (PageNumber > 1);
        public bool HasNextPage => (PageNumber < TotalPages);        
    }
}
