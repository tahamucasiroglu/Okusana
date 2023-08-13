using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.Request;
using Okusana.DTOs.Concrete.User;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<GetUserDTO, AddUserDTO, UpdateUserDTO, DeleteUserDTO>
    {
        private new readonly IUserService service;
        public UserController(IUserService service) : base(service) 
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

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetByEmail([FromBody] StringRequestDTO Value) => new OkObjectResult(service.GetByEmail(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetByIdentity([FromBody] StringRequestDTO Value) => new OkObjectResult(service.GetByIdentity(Value.Value));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByBirthdate([FromBody] DateTimeRequestDTO Value) => new OkObjectResult(service.GetsByBirthdate(Value.Date));

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public IActionResult GetsByStatus([FromBody] StringRequestDTO Value) => new OkObjectResult(service.GetsByStatus(Value.Value));
        #endregion

        //[HttpGet("[action]")]
        //[ServiceFilter(typeof(LogConnectionAttribute))]
        //public async Task<IActionResult> GetById([FromBody] GuidRequestDTO Value) => new OkObjectResult( await service.GetByIdAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetById([FromQuery] Guid Value) => new OkObjectResult(await service.GetByIdAsync(Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByName([FromBody] StringRequestDTO Value) => new OkObjectResult( await service.GetsByNameAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetByEmail([FromBody] StringRequestDTO Value) => new OkObjectResult( await service.GetByEmailAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetByIdentity([FromBody] StringRequestDTO Value) => new OkObjectResult( await service.GetByIdentityAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByBirthdate([FromBody] DateTimeRequestDTO Value) => new OkObjectResult( await service.GetsByBirthdateAsync(Value.Date));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetsByStatus([FromBody] StringRequestDTO Value) => new OkObjectResult( await service.GetsByStatusAsync(Value.Value));

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO Value) => new OkObjectResult(await service.LoginAsync(Value.Email, Value.Password));

        [HttpGet("[action]")]
        [AllowAnonymous]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> Logout([FromBody] LoginRequestDTO Value) => new OkObjectResult(await service.LogoutAsync());





    }
}
