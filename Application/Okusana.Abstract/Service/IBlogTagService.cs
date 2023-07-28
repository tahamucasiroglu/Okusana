
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.BlogTag;

namespace Okusana.Abstract.Service
{
    public interface IBlogTagService : IService<GetBlogTagDTO, AddBlogTagDTO, UpdateBlogTagDTO>
    {
    }
}
