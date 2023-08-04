
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.SubCategory;

namespace Okusana.Abstract.Service
{
    public interface ISubCategoryService : IService<GetSubCategoryDTO, AddSubCategoryDTO, UpdateSubCategoryDTO>
    {
        public IActionResult GetsByCategoryId(Guid Id);
        public IActionResult GetsByName(string Name);
        public Task<IActionResult> GetsByCategoryIdAsync(Guid Id);
        public Task<IActionResult> GetsByNameAsync(string Name);
    }
}
