
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.BlogTag;

namespace Okusana.Abstract.Service
{
    public interface IBlogTagService : IService<GetBlogTagDTO, AddBlogTagDTO, UpdateBlogTagDTO>
    {
        public IActionResult GetsByBlogId(Guid Id);
        public IActionResult GetsByTagId(Guid Id);
        public IActionResult GetsByName(string Name);

        public Task<IActionResult> GetsByBlogIdAsync(Guid Id);
        public Task<IActionResult> GetsByTagIdAsync(Guid Id);
        public Task<IActionResult> GetsByNameAsync(string Name);
    }
}
