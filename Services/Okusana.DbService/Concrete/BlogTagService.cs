using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.BlogTag;
using Okusana.Entities.Concrete;
using Okusana.Models.HateoasModel;
using Okusana.Returns.Abstract;

namespace Okusana.DbService.Concrete
{
    public class BlogTagService : AbstractService<BlogTag, GetBlogTagDTO, AddBlogTagDTO, UpdateBlogTagDTO>, IBlogTagService
    {
        public BlogTagService(IBlogTagRepository repository, IMapper mapper, IBlogTagHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, hateoas, configuration, httpContextAccessor) { }

        public IActionResult GetsByBlogId(Guid Id)
        {
            IReturnModel<IEnumerable<BlogTag>> result = repository.GetAll(e => e.BlogId == Id);
            return ConvertToReturn<GetBlogTagDTO, BlogTag>(result, mapper);
        }

        public IActionResult GetsByName(string Name)
        {
            IReturnModel<IEnumerable<BlogTag>> result = repository.GetAll(e => e.HashTag.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetBlogTagDTO, BlogTag>(result, mapper);
        }

        public IActionResult GetsByTagId(Guid Id)
        {
            IReturnModel<IEnumerable<BlogTag>> result = repository.GetAll(e => e.TagId == Id);
            return ConvertToReturn<GetBlogTagDTO, BlogTag>(result, mapper);
        }

        public async Task<IActionResult> GetsByBlogIdAsync(Guid Id)
        {
            IReturnModel<IEnumerable<BlogTag>> result = await repository.GetAllAsync(e => e.BlogId == Id);
            return ConvertToReturn<GetBlogTagDTO, BlogTag>(result, mapper);
        }

        public async Task<IActionResult> GetsByNameAsync(string Name)
        {
            IReturnModel<IEnumerable<BlogTag>> result = await repository.GetAllAsync(e => e.HashTag.Name.ToLower().Contains(Name.ToLower()));
            return ConvertToReturn<GetBlogTagDTO, BlogTag>(result, mapper);
        }

        public async Task<IActionResult> GetsByTagIdAsync(Guid Id)
        {
            IReturnModel<IEnumerable<BlogTag>> result = await repository.GetAllAsync(e => e.TagId == Id);
            return ConvertToReturn<GetBlogTagDTO, BlogTag>(result, mapper);
        }
    }
}
