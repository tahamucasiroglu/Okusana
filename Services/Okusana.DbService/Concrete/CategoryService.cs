using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.BlogTag;
using Okusana.DTOs.Concrete.Category;
using Okusana.Entities.Concrete;
using Okusana.Models.HateoasModel;
using Okusana.Returns.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.DbService.Concrete
{
    public class CategoryService : AbstractService<Category, GetCategoryDTO, AddCategoryDTO, UpdateCategoryDTO>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IMapper mapper, ICategoryHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, hateoas, configuration, httpContextAccessor) { }

        public IActionResult GetById(Guid Id)
        {
            IReturnModel<Category> result = repository.Get(e => e.Id == Id);
            return ConvertToReturn<GetCategoryDTO, Category>(result, mapper);
        }

        public IActionResult GetsByName(string Name)
        {
            IReturnModel<IEnumerable<Category>> result = repository.GetAll(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetCategoryDTO, Category>(result, mapper);
        }

        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            IReturnModel<Category> result = await repository.GetAsync(e => e.Id == Id);
            return ConvertToReturn<GetCategoryDTO, Category>(result, mapper);
        }

        public async Task<IActionResult> GetsByNameAsync(string Name)
        {
            IReturnModel<IEnumerable<Category>> result = await repository.GetAllAsync(e => e.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetCategoryDTO, Category>(result, mapper);
        }
    }
}
