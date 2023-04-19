namespace BookWormProject.DTOs
{
    public class PageInfoDTO
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public string NextPageUrl { get; set; }
        public string PreviousPageUrl { get; set; }
    }
}
