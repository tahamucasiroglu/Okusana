
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.HashTag;

namespace Okusana.Abstract.Service
{
    public interface IHashTagService : IService<GetHashTagDTO, AddHashTagDTO, UpdateHashTagDTO>
    {
        public IActionResult GetById(Guid Id);
        public IActionResult GetByName(string Name);
        public Task<IActionResult> GetByIdAsync(Guid Id);
        public Task<IActionResult> GetByNameAsync(string Name);
    }
}
