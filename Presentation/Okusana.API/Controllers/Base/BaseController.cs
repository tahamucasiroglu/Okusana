using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.API.Attributes;
using Okusana.API.Extensions;
using Okusana.Constants;
using Okusana.DTOs.Abstract;

namespace Okusana.API.Controllers.Base
{
    abstract public class BaseController : ControllerBase
    {
        internal readonly IService service;
        public BaseController(IService service)
        {
            this.service = service;
        }
    }
    abstract public class BaseController<TGet> : BaseController, IBaseController
        where TGet : class, IGetDTO, new()
    {
        internal new readonly IService<TGet> service;
        public BaseController(IService<TGet> service) : base(service)
        {
            this.service= service;
        }
        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public IActionResult GetAll()
        {
            return new OkObjectResult(service.GetAll());
        }
    }
    abstract public class BaseController<TGet, TAdd> : BaseController<TGet>, IBaseController<TAdd>
        where TGet : class, IGetDTO, new()
        where TAdd : class, IAddDTO, new()
    {
        internal new readonly IService<TGet, TAdd> service;
        public BaseController(IService<TGet, TAdd> service) : base(service)
        {
            this.service = service;
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        [Authorize(UserStatus.Admin)]
        public IActionResult Add([FromBody] TAdd survey)
        {
            return new OkObjectResult(ModelState.IsValid ? service.Add(survey) : ModelState.ReturnError());
        }
    }
    abstract public class BaseController<TGet, TAdd, TUpdate> : BaseController<TGet, TAdd>, IBaseController<TAdd, TUpdate>
        where TGet : class, IGetDTO, new()
        where TAdd : class, IAddDTO, new()
        where TUpdate : class, IUpdateDTO, new()
    {
        internal new readonly IService<TGet, TAdd, TUpdate> service;
        public BaseController(IService<TGet, TAdd, TUpdate> service) : base(service)
        {
            this.service = service;
        }
        [HttpPut("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        [Authorize(UserStatus.Admin)]
        public IActionResult Update([FromBody] TUpdate survey)
        {
            return new OkObjectResult(ModelState.IsValid ? service.Update(survey) : ModelState.ReturnError());
        }
    }
    abstract public class BaseController<TGet, TAdd, TUpdate, TDelete> : BaseController<TGet, TAdd, TUpdate>, IBaseController<TAdd, TUpdate, TDelete>
        where TGet : class, IGetDTO, new()
        where TAdd : class, IAddDTO, new()
        where TUpdate : class, IUpdateDTO, new()
        where TDelete : class, IDeleteDTO, new()
    {
        public BaseController(IService<TGet, TAdd, TUpdate> service) : base(service) { }

        [HttpDelete("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        [Authorize(UserStatus.Admin)]
        public IActionResult Delete([FromBody] TDelete survey)
        {
            return new OkObjectResult(ModelState.IsValid ? service.Delete(survey.Id) : ModelState.ReturnError());
        }
    }
}
