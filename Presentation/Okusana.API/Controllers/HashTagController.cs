using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.HashTag;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashTagController : BaseController<GetHashTagDTO, AddHashTagDTO, UpdateHashTagDTO, DeleteHashTagDTO>
    {
        public HashTagController(IHashTagService service) : base(service) { }
    }
}
