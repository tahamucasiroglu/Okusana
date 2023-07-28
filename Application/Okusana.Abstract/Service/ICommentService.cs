
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Concrete.Comment;

namespace Okusana.Abstract.Service
{
    public interface ICommentService : IService<GetCommentDTO, AddCommentDTO, UpdateCommentDTO>
    {
    }
}
