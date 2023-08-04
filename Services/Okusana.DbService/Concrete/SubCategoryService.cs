using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.DTOs.Concrete.SubCategory;
using Okusana.Entities.Concrete;
using Okusana.Returns.Abstract;
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

        public IActionResult GetsByCategoryId(Guid Id)
        {
            IReturnModel<SubCategory> result = repository.Get(e => e.CategoryId == Id);
            return ConvertToReturn<GetSubCategoryDTO, SubCategory>(result, mapper);
        }

        public IActionResult GetsByName(string Name)
        {
            IReturnModel<SubCategory> result = repository.Get(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetSubCategoryDTO, SubCategory>(result, mapper);
        }

        public async Task<IActionResult> GetsByCategoryIdAsync(Guid Id)
        {
            IReturnModel<SubCategory> result = await repository.GetAsync(e => e.CategoryId == Id);
            return ConvertToReturn<GetSubCategoryDTO, SubCategory>(result, mapper);
        }

        public async Task<IActionResult> GetsByNameAsync(string Name)
        {
            IReturnModel<SubCategory> result = await repository.GetAsync(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetSubCategoryDTO, SubCategory>(result, mapper);
        }
    }
}
