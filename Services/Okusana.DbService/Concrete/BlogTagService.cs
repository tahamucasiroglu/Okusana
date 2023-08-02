using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.Abstract.Service.Base;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.DTOs.Concrete.BlogTag;
using Okusana.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DbService.Concrete
{
    public class BlogTagService : AbstractService<BlogTag, GetBlogTagDTO, AddBlogTagDTO, UpdateBlogTagDTO>, IBlogTagService
    {
        public BlogTagService(IBlogTagRepository repository, IMapper mapper) : base(repository, mapper) { }

    }
}
