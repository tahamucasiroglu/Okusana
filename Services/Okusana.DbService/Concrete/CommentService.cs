using AutoMapper;
using Okusana.Abstract.Repository;
using Okusana.DbService.Base;
using Okusana.DTOs.Concrete.Comment;
using Okusana.Entities.Concrete;


namespace Okusana.DbService.Concrete
{
    public class CommentService : AbstractService<Comment, GetCommentDTO, AddCommentDTO, UpdateCommentDTO>
    {
        public CommentService(ICommentRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
