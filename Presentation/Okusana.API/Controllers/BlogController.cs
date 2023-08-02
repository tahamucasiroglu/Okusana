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

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        [ServiceFilter(typeof(DateTimeRequestDTOValidation))] // denenecek
        public IActionResult GetByDate([FromBody]DateTimeRequestDTO Value)
        {
            return new OkObjectResult(service.GetByDate(Value.Date));
        }


        





    }
}
