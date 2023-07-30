using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.SubCategory;
using Okusana.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DbService.Concrete
{
    public class SubCategoryService : AbstractService<SubCategory, GetSubCategoryDTO, AddSubCategoryDTO, UpdateSubCategoryDTO>, ISubCategoryService
    {
        public SubCategoryService(ISubCategoryRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
