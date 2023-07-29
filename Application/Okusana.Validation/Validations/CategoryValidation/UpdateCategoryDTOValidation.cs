using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.Category;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.CategoryValidation
{
    public class UpdateCategoryDTOValidation : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
            RuleFor(e => e.Name).MaximumLength(DbSettings.Category.Name.Length).WithMessage($"Adı {DbSettings.Category.Name.Length} karakterden fazla olamaz").Required(DbSettings.Category.Name.Required, "Başlık olamadan kategory eklenemez");
            RuleFor(e => e.Description).MaximumLength(DbSettings.Category.Description.Length).WithMessage($"Başlık {DbSettings.Category.Description.Length} karakterden fazla olamaz");
        }
    }
}
