using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.Blog;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController<GetBlogDTO, AddBlogDTO, UpdateBlogDTO, DeleteBlogDTO>
    {
        public BlogController(IBlogService service) : base(service)
        {
        }





    }
}
