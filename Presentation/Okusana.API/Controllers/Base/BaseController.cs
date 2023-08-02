using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service.Base;
using Okusana.API.Extensions;
using Okusana.DTOs.Abstract;

namespace Okusana.API.Controllers.Base
{
    public class BaseController : ControllerBase, IBaseController
    {
        internal readonly IService service;
        public BaseController(IService service)
        {
            this.service = service;
        }

    }
    public class BaseController<TGet> : BaseController
        where TGet : class, IGetDTO, new()
    {
        internal new readonly IService<TGet> service;
        public BaseController(IService<TGet> service) : base(service)
        {
            this.service= service;
        }
    }
    public class BaseController<TGet, TAdd> : BaseController<TGet>, IBaseController<TAdd>
        where TGet : class, IGetDTO, new()
        where TAdd : class, IAddDTO, new()
    {
        internal new readonly IService<TGet, TAdd> service;
        public BaseController(IService<TGet, TAdd> service) : base(service)
        {
            this.service = service;
        }
        [HttpPost("[action]")]
        public IActionResult Add([FromBody] TAdd survey)
        {
            return new OkObjectResult(ModelState.IsValid ? service.Add(survey) : ModelState.ReturnError());
        }
    }
    public class BaseController<TGet, TAdd, TUpdate> : BaseController<TGet, TAdd>, IBaseController<TAdd, TUpdate>
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
        public IActionResult Update([FromBody] TUpdate survey)
        {
            return new OkObjectResult(ModelState.IsValid ? service.Update(survey) : ModelState.ReturnError());
        }
    }
    public class BaseController<TGet, TAdd, TUpdate, TDelete> : BaseController<TGet, TAdd, TUpdate>, IBaseController<TAdd, TUpdate, TDelete>
        where TGet : class, IGetDTO, new()
        where TAdd : class, IAddDTO, new()
        where TUpdate : class, IUpdateDTO, new()
        where TDelete : class, IDeleteDTO, new()
    {
        public BaseController(IService<TGet, TAdd, TUpdate> service) : base(service) { }

        [HttpDelete("[action]")]
        public IActionResult Delete([FromBody] TDelete survey)
        {
            return new OkObjectResult(ModelState.IsValid ? service.Delete(survey.Id) : ModelState.ReturnError());
        }
    }
}
