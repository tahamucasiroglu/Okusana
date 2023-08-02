using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Returns.Abstract;

namespace Okusana.Abstract.Service
{
    public interface IBlogService : IService<GetBlogDTO, AddBlogDTO, UpdateBlogDTO>
    {
        public IReturnModel<IEnumerable<GetBlogDTO>> GetByDate(DateTime date);

    }
}
