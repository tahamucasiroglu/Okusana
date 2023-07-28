using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Category;

namespace Okusana.Abstract.Service
{
    public interface ICategoryService : IService<GetCategoryDTO, AddCategoryDTO,UpdateCategoryDTO>
    {
    }
}
