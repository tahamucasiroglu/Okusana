using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.DTOs.Concrete.BlogTag;
using Okusana.DTOs.Concrete.Request;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTagController : BaseController<GetBlogTagDTO, AddBlogTagDTO, UpdateBlogTagDTO, DeleteBlogTagDTO>
    {
        private new readonly IBlogTagService service;
        public BlogTagController(IBlogTagService service) : base(service) 
        {
            this.service = service;
        }
        #region Senkron
        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByBlogId([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetsByBlogId(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByTagId([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetsByTagId(Value.Value));


        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByName([FromBody] StringRequestDTO Value) => new OkObjectResult(service.GetsByName(Value.Value));
        #endregion

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByBlogId([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetsByBlogIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByTagId([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetsByTagIdAsync(Value.Value));


        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByName([FromBody] StringRequestDTO Value) => new OkObjectResult(await service.GetsByNameAsync(Value.Value));





    }
}
