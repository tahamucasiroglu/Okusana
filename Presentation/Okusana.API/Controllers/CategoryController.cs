using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.Category;
using Okusana.DTOs.Concrete.Request;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<GetCategoryDTO, AddCategoryDTO, UpdateCategoryDTO, DeleteCategoryDTO>
    {
        private new readonly ICategoryService service;
        public CategoryController(ICategoryService service) : base(service) 
        {
            this.service = service;
        }


        #region Senkron
        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetById(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByName([FromBody] StringRequestDTO Value) => new OkObjectResult(service.GetsByName(Value.Value));
        #endregion

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetByIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByName([FromBody] StringRequestDTO Value) => new OkObjectResult(await service.GetsByNameAsync(Value.Value));


    }
}
