using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Repository.Base;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Entities.Concrete;
using Okusana.Extensions;
using Okusana.Mapper.Extensions;
using Okusana.Returns.Abstract;
using Okusana.Returns.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DbService.Concrete
{
    public class BlogService : AbstractService<Blog, GetBlogDTO, AddBlogDTO, UpdateBlogDTO>, IBlogService
    {
        public BlogService(IBlogRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IReturnModel<IEnumerable<GetBlogDTO>> GetByDate(DateTime date)
        {
            IReturnModel<IEnumerable<Blog>> result = repository.GetAll(e => e.CreateDate.IsSameCalenderDate(date));
            if (!result.Status) return new ErrorReturnModel<IEnumerable<GetBlogDTO>>(result.Message ,result.Exception);
            return new SuccessReturnModel<IEnumerable<GetBlogDTO>>("", result.Data?.ConvertToEntity(mapper));
        }
    }
}
