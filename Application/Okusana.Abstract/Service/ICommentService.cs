
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Comment;

namespace Okusana.Abstract.Service
{
    public interface ICommentService : IService<GetCommentDTO, AddCommentDTO, UpdateCommentDTO>
    {
        public IActionResult GetById(Guid Id);
        public IActionResult GetsByRate(int Rate);
        public IActionResult GetsByBlogId(Guid Id);
        public IActionResult GetsByUserId(Guid Id);

        public Task<IActionResult> GetByIdAsync(Guid Id);
        public Task<IActionResult> GetsByRateAsync(int Rate);
        public Task<IActionResult> GetsByBlogIdAsync(Guid Id);
        public Task<IActionResult> GetsByUserIdAsync(Guid Id);
    }
}
