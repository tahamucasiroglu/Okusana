using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public BlogService(IBlogRepository repository, IMapper mapper, IBlogHateoas hateoas) : base(repository, mapper, hateoas) { }

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


        public IActionResult GetLasts(int count)
        {
            IReturnModel<IEnumerable<Blog>> result = repository.GetAll(^0..^count);
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


        public async Task<IActionResult> GetLastsAsync(int count)
        {
            IReturnModel<IEnumerable<Blog>> result = await repository.GetAllAsync(^0..^count);
            return ConvertToReturn<GetBlogDTO, Blog>(result, mapper, hateoas);
        }




    }
}
