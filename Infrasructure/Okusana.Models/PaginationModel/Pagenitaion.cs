using Okusana.Abstract.Models.PaginationModel;

namespace Okusana.Models.PaginationModel
{
    public class Pagenitaion : IPagination
    {
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public bool HasBeforePage { get; set; }
        public bool HasAfterPage { get; set; }
        public Pagenitaion(int pageSize, int pageCount, int currentPage, bool hasBeforePage, bool hasAfterPage)
        {
            PageSize = pageSize;
            PageCount = pageCount;
            CurrentPage = currentPage;
            HasBeforePage = hasBeforePage;
            HasAfterPage = hasAfterPage;
        }
    }
}
