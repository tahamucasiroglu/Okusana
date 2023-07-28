using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Blog;

namespace Okusana.Abstract.Service
{
    public interface IBlogService : IService<GetBlogDTO, AddBlogDTO, UpdateBlogDTO>
    {
        
    }
}
