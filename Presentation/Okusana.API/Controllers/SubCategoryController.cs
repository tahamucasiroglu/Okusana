using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.Request;
using Okusana.DTOs.Concrete.SubCategory;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : BaseController<GetSubCategoryDTO, AddSubCategoryDTO, UpdateSubCategoryDTO, DeleteSubCategoryDTO>
    {
        private new readonly ISubCategoryService service;
        public SubCategoryController(ISubCategoryService service) : base(service)
        {
            this.service = service;
        }

        #region Senkron
        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByCategoryId([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetsByCategoryId(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByName([FromBody] StringRequestDTO Value) => new OkObjectResult(service.GetsByName(Value.Value));
        #endregion

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByCategoryId([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetsByCategoryIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByName([FromBody] StringRequestDTO Value) => new OkObjectResult(await service.GetsByNameAsync(Value.Value));
    }
}
