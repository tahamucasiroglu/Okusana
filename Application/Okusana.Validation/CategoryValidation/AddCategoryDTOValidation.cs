using FluentValidation;
using Okusana.DTOs.Concrete.Category;
using Okusana.Validation.Extensions;

namespace Okusana.Validation.CategoryValidation
{
    public class AddCategoryDTOValidation : AbstractValidator<AddCategoryDTO>
    {
        public AddCategoryDTOValidation()
        {
            RuleFor(e => e.Name).NameValidation();
            RuleFor(e => e.Description).DescriptionValidation();
        }
    }
}
