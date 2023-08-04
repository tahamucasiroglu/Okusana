using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.DTOs.Concrete.Request;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashTagController : BaseController<GetHashTagDTO, AddHashTagDTO, UpdateHashTagDTO, DeleteHashTagDTO>
    {
        private new readonly IHashTagService service;
        public HashTagController(IHashTagService service) : base(service) 
        {
            this.service = service;
        }

        #region Senkron
        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult(service.GetById(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetByName([FromBody] StringRequestDTO Value) => new OkObjectResult(service.GetByName(Value.Value));
        #endregion
        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult(await service.GetByIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetByName([FromBody] StringRequestDTO Value) => new OkObjectResult(await service.GetByNameAsync(Value.Value));
    }
}
