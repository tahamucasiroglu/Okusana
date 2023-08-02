using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.DTOs.Concrete.BlogTag;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTagController : BaseController<GetBlogTagDTO, AddBlogTagDTO, UpdateBlogTagDTO, DeleteBlogTagDTO>
    {
        public BlogTagController(IBlogTagService service) : base(service) { }

    }
}
