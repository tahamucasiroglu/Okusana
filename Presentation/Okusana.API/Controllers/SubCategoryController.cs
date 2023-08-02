using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Attributes;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.SubCategory;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : BaseController<GetSubCategoryDTO, AddSubCategoryDTO, UpdateSubCategoryDTO, DeleteSubCategoryDTO>
    {
        public SubCategoryController(ISubCategoryService service) : base(service)
        {

        }
    }
}
