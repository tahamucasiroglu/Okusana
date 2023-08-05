using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.Comment;
using Okusana.Validation.Extensions;


namespace Okusana.Validation.Validations.CommentValidation
{
    public class UpdateCommentDTOValidation : AbstractValidator<UpdateCommentDTO>
    {
        public UpdateCommentDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
            RuleFor(e => e.Content).MaximumLength(DbSettings.Comment.Content.Length).Required(DbSettings.Comment.Content.Required, "En azından iyi yaz");
            RuleFor(e => e.Rate).Must(e => e == null || e >= DbSettings.Comment.Rate.Min && e <= DbSettings.Comment.Rate.Max);
        }
    }
}
