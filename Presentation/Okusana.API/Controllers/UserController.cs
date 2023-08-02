using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.User;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<GetUserDTO, AddUserDTO, UpdateUserDTO, DeleteUserDTO>
    {
        public UserController(IUserService service) : base(service) { }
    }
}
