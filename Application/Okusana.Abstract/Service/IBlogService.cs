using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Returns.Abstract;

namespace Okusana.Abstract.Service
{
    public interface IBlogService : IService<GetBlogDTO, AddBlogDTO, UpdateBlogDTO>
    {
        public IActionResult GetsByDate(DateTime date);
        public IActionResult GetsByDateRange(DateTime startDate, DateTime endDate);
        public IActionResult Search(string Text);
        public IActionResult GetById(Guid Id);
        public IActionResult GetLasts(int count);

        public Task<IActionResult> GetsByDateAsync(DateTime date);
        public Task<IActionResult> GetsByDateRangeAsync(DateTime startDate, DateTime endDate);
        public Task<IActionResult> SearchAsync(string Text);
        public Task<IActionResult> GetByIdAsync(Guid Id);
        public Task<IActionResult> GetLastsAsync(int count);

    }
}
