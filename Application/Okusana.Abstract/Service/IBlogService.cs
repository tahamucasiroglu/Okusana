using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Returns.Abstract;

namespace Okusana.Abstract.Service
{
    public interface IBlogService : IService<GetBlogDTO, AddBlogDTO, UpdateBlogDTO>
    {
        public IActionResult GetByDate(DateTime date);
        public IActionResult GetByDateRange(DateTime startDate, DateTime endDate);
        public IActionResult Search(string Text);

    }
}
