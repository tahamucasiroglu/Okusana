using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.Category;
using Okusana.Validation.Extensions;

namespace Okusana.Validation.Validations.CategoryValidation
{
    public class AddCategoryDTOValidation : AbstractValidator<AddCategoryDTO>
    {
        public AddCategoryDTOValidation()
        {
            RuleFor(e => e.Name).MaximumLength(DbSettings.Category.Name.Length).WithMessage($"Adı {DbSettings.Category.Name.Length} karakterden fazla olamaz").Required(DbSettings.Category.Name.Required, "Başlık olamadan kategory eklenemez");
            RuleFor(e => e.Description).MaximumLength(DbSettings.Category.Description.Length).WithMessage($"Başlık {DbSettings.Category.Description.Length} karakterden fazla olamaz");
        }
    }
}
