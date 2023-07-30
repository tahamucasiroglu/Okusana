using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Repository.Base;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Entities.Concrete;
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

    }
}
