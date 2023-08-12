using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Entities.Concrete;
using Okusana.Extensions;
using Okusana.Models.HateoasModel;
using Okusana.Returns.Abstract;

namespace Okusana.DbService.Concrete
{
    public class BlogService : AbstractService<Blog, GetBlogDTO, AddBlogDTO, UpdateBlogDTO>, IBlogService
    {
        public BlogService(IBlogRepository repository, IMapper mapper, IBlogHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, hateoas, configuration, httpContextAccessor) { }

        public IActionResult GetsByDate(DateTime date)
        {
            IReturnModel<IEnumerable<Blog>> result = repository.GetAll(e => e.CreateDate.IsSameCalenderDate(date));
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public IActionResult GetsByDateRange(DateTime startDate, DateTime endDate)
        {
            IReturnModel<IEnumerable<Blog>> result = repository.GetAll(e => e.CreateDate.IsInRange(startDate, endDate));
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public IActionResult GetById(Guid Id)
        {
            IReturnModel<Blog> result = repository.Get(e => e.Id == Id);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public IActionResult Search(string Text)
        {
            IReturnModel<IEnumerable<Blog>> result = repository.GetAll(e => e.Title.ToLower().Contains(Text.ToLower()));
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }


        public IActionResult GetsLasts(int count)
        {
            IReturnModel<int> repositoryCount = repository.Count();
            if (repositoryCount.Data == 0 || !repositoryCount.Status) return EmptyDataReturn<GetBlogDTO, IEnumerable<Blog>>();
            IReturnModel<IEnumerable<Blog>> result = repository.GetAll(e => e.CreateDate, (repositoryCount.Data - count)..repositoryCount.Data);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetsByDateAsync(DateTime date)
        {
            IReturnModel<IEnumerable<Blog>> result = await repository.GetAllAsync(e => e.CreateDate.IsSameCalenderDate(date));
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            IReturnModel<IEnumerable<Blog>> result = await repository.GetAllAsync(e => e.CreateDate.IsInRange(startDate, endDate));
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            IReturnModel<Blog> result = await repository.GetAsync(e => e.Id == Id);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public async Task<IActionResult> SearchAsync(string Text)
        {
            IReturnModel<IEnumerable<Blog>> result = await repository.GetAllAsync(e => e.Title.ToLower().Contains(Text.ToLower()));
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }


        public async Task<IActionResult> GetsLastsAsync(int count)
        {
            IReturnModel<int> repositoryCount = await repository.CountAsync();
            if (repositoryCount.Data == 0 || !repositoryCount.Status) return EmptyDataReturn<GetBlogDTO, IEnumerable<Blog>>();
            IReturnModel<IEnumerable<Blog>> result = await repository.GetAllAsync(e => e.CreateDate, (repositoryCount.Data-count)..repositoryCount.Data);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public IActionResult GetsByCategoryId(Guid Id)
        {
            IReturnModel<IEnumerable<Blog>> result = repository.GetAll(e => e.SubCategory.CategoryId == Id);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetsByCategoryIdAsync(Guid Id)
        {
            IReturnModel<IEnumerable<Blog>> result = await repository.GetAllAsync(e => e.SubCategory.CategoryId == Id);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public IActionResult GetsSubByCategoryId(Guid Id)
        {
            IReturnModel<IEnumerable<Blog>> result = repository.GetAll(e => e.SubCategoryId == Id);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }

        public async Task<IActionResult> GetsSubByCategoryIdAsync(Guid Id)
        {
            IReturnModel<IEnumerable<Blog>> result = await repository.GetAllAsync(e => e.SubCategoryId == Id);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }
    }
}
