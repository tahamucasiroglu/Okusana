using FluentValidation;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Validation.Extensions;

namespace Okusana.Validation.BlogValidation
{
    public class DeleteBlogDTOValidation : AbstractValidator<DeleteBlogDTO>
    {
        public DeleteBlogDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
        }
    }
}
