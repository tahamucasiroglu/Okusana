using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.DTOs.Concrete.Request;
using Okusana.Validation.Validations.RequestValidation;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController<GetBlogDTO, AddBlogDTO, UpdateBlogDTO, DeleteBlogDTO>
    {
        private new readonly IBlogService service;
        public BlogController(IBlogService service) : base(service)
        {
            this.service = service;
        }

        #region Senkron
        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetById(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //[ServiceFilter(typeof(DateTimeRequestDTOValidation))] // denenecek
        //public IActionResult GetsByDate([FromBody] DateTimeRequestDTO Value) => new OkObjectResult(service.GetsByDate(Value.Date));


        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByDateRange([FromBody] DateTimeRangeRequestDTO Value) => new OkObjectResult(service.GetsByDateRange(Value.StartDate, Value.EndDate));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult Search([FromBody] StringRequestDTO Value) => new OkObjectResult(service.Search(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetLasts([FromBody] IntRequestDTO Value) => new OkObjectResult(service.GetLasts(Value.Value));
        #endregion

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetByIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        [ServiceFilter(typeof(DateTimeRequestDTOValidation))] // denenecek
        public async Task<IActionResult> GetsByDate([FromBody] DateTimeRequestDTO Value) => new OkObjectResult(await service.GetsByDateAsync(Value.Date));


        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByDateRange([FromBody] DateTimeRangeRequestDTO Value) => new OkObjectResult(await service.GetsByDateRangeAsync(Value.StartDate, Value.EndDate));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> Search([FromBody] StringRequestDTO Value) => new OkObjectResult(await service.SearchAsync(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public async Task<IActionResult> GetLasts([FromQuery] int Value) => new OkObjectResult(await service.GetsLastsAsync(Value));
        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetLasts([FromQuery] int Value) => new OkObjectResult(await service.GetsLastsAsync(Value));
        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public async Task<IActionResult> GetByCategoryId([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetsByCategoryIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetByCategoryId([FromQuery] Guid Value) => new OkObjectResult(await service.GetsByCategoryIdAsync(Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public async Task<IActionResult> GetBySubCategoryId([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetsSubByCategoryIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetBySubCategoryId([FromQuery] Guid Value) => new OkObjectResult(await service.GetsSubByCategoryIdAsync(Value));


    }
}
