using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Service;
using Okusana.API.Controllers.Base;
using Okusana.DTOs.Concrete.BlogTag;
using Okusana.DTOs.Concrete.Comment;

namespace Okusana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController<GetCommentDTO, AddCommentDTO, UpdateCommentDTO, DeleteCommentDTO>
    {
        public CommentController(ICommentService service) : base(service) { }
    }
}
