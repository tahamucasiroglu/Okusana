using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Comment;
using Okusana.Entities.Concrete;


namespace Okusana.DbService.Concrete
{
    public class CommentService : AbstractService<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO>, ICommentService
    {
        public CommentService(ICommentRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
