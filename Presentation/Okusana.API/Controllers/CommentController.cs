using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.BlogTag;
using Okusana.DTOs.Concrete.Comment;
using Okusana.DTOs.Concrete.Request;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController<GetCommentDTO, AddCommentDTO, UpdateCommentDTO, DeleteCommentDTO>
    {
        private new readonly ICommentService service;
        public CommentController(ICommentService service) : base(service) 
        {
            this.service = service;
        }

        #region Senkron
        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetById(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByRate([FromBody] IntRequestDTO Value) => new OkObjectResult(service.GetsByRate(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByBlogId([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetsByBlogId(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByUserId([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetsByUserId(Value.Value));
        #endregion
        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetByIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByRate([FromBody] IntRequestDTO Value) => new OkObjectResult(await service.GetsByRateAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByBlogId([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetsByBlogIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByUserId([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetsByUserIdAsync(Value.Value));



    }
}
