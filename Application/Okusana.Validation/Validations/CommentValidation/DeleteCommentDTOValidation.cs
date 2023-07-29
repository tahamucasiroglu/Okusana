using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.Comment;
using Okusana.Validation.Extensions;

namespace Okusana.Validation.Validations.CommentValidation
{
    public class DeleteCommentDTOValidation : AbstractValidator<DeleteCommentDTO>
    {
        public DeleteCommentDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
        }
    }
}
