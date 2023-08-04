using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Category;

namespace Okusana.Abstract.Service
{
    public interface ICategoryService : IService<GetCategoryDTO, AddCategoryDTO,UpdateCategoryDTO>
    {
        public IActionResult GetById(Guid Id);
        public IActionResult GetsByName(string Name);
        public Task<IActionResult> GetByIdAsync(Guid Id);
        public Task<IActionResult> GetsByNameAsync(string Name);
    }
    

}
