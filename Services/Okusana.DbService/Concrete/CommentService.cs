using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Category;
using Okusana.DTOs.Concrete.Comment;
using Okusana.Entities.Concrete;
using Okusana.Models.HateoasModel;
using Okusana.Returns.Abstract;

namespace Okusana.DbService.Concrete
{
    public class CommentService : AbstractService<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO>, ICommentService
    {
        public CommentService(ICommentRepository repository, IMapper mapper, ICommentHateoas hateoas) : base(repository, mapper, hateoas) { }

        public IActionResult GetById(Guid Id)
        {
            IReturnModel<Comment> result = repository.Get(e => e.Id == Id);
            return ConvertToReturn<GetCommentDTO, Comment>(result, mapper);
        }

        public IActionResult GetsByBlogId(Guid Id)
        {
            IReturnModel<IEnumerable<Comment>> result = repository.GetAll(e => e.BlogId == Id);
            return ConvertToReturn<GetCommentDTO, Comment>(result, mapper);
        }

        public IActionResult GetsByRate(int Rate)
        {
            IReturnModel<IEnumerable<Comment>> result = repository.GetAll(e => e.Rate == Rate);
            return ConvertToReturn<GetCommentDTO, Comment>(result, mapper);
        }

        public IActionResult GetsByUserId(Guid Id)
        {
            IReturnModel<IEnumerable<Comment>> result = repository.GetAll(e => e.UserId == Id);
            return ConvertToReturn<GetCommentDTO, Comment>(result, mapper);
        }

        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            IReturnModel<Comment> result = await repository.GetAsync(e => e.Id == Id);
            return ConvertToReturn<GetCommentDTO, Comment>(result, mapper);
        }

        public async Task<IActionResult> GetsByBlogIdAsync(Guid Id)
        {
            IReturnModel<IEnumerable<Comment>> result = await repository.GetAllAsync(e => e.BlogId == Id);
            return ConvertToReturn<GetCommentDTO, Comment>(result, mapper);
        }

        public async Task<IActionResult> GetsByRateAsync(int Rate)
        {
            IReturnModel<IEnumerable<Comment>> result = await repository.GetAllAsync(e => e.Rate == Rate);
            return ConvertToReturn<GetCommentDTO, Comment>(result, mapper);
        }

        public async Task<IActionResult> GetsByUserIdAsync(Guid Id)
        {
            IReturnModel<IEnumerable<Comment>> result = await repository.GetAllAsync(e => e.UserId == Id);
            return ConvertToReturn<GetCommentDTO, Comment>(result, mapper);
        }
    }
}
