using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.Category;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController<GetCategoryDTO, AddCategoryDTO, UpdateCategoryDTO, DeleteCategoryDTO>
    {
        public CategoryController(ICategoryService service) : base(service) {

        }


        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

    }
}
