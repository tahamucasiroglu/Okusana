using FluentValidation;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Validation.Extensions;

namespace Okusana.Validation.BlogValidation
{
    public class UpdateBlogDTOValidation : AbstractValidator<UpdateBlogDTO>
    {
        public UpdateBlogDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
            RuleFor(e => e.SubCategoryId).SubCategoryIdValidation();
            RuleFor(e => e.Title).TitleValidation();
            RuleFor(e => e.Content).ContentValidation();
            RuleFor(e => e.PublicationDate).PublicationDateValidation();
        }
    }
}
