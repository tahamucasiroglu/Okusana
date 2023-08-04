namespace Okusana.API.Models.PaginationModel
{
    public interface IPagination
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public bool HasBeforePage { get; set; }
        public bool HasAfterPage { get; set; }
    }
}
