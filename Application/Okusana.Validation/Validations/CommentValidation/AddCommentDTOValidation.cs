using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.Comment;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.CommentValidation
{
    public class AddCommentDTOValidation : AbstractValidator<AddCommentDTO>
    {
        public AddCommentDTOValidation()
        {
            RuleFor(e => e.BlogId).Required(DbSettings.Comment.BlogId.Required, "BlogId siz ekleyemem");
            RuleFor(e => e.UserId).Required(DbSettings.Comment.UserId.Required, "Bunu hangi üye eklemek itiyor");
            RuleFor(e => e.Content).MaximumLength(DbSettings.Comment.Content.Length).Required(DbSettings.Comment.Content.Required, "En azından iyi yaz");
            RuleFor(e => e.Rate).Must(e => e == null || e >= DbSettings.Comment.Rate.Min && e <= DbSettings.Comment.Rate.Max);
            RuleFor(e => e.IsLike).Required(DbSettings.Comment.IsLike.Required, "Beğendi mi beğenmedi mi");
        }
    }
}
