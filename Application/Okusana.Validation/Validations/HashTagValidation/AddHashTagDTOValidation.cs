using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.Validation.Extensions;

namespace Okusana.Validation.Validations.HashTagValidation
{
    public class AddHashTagDTOValidation : AbstractValidator<AddHashTagDTO>
    {
        public AddHashTagDTOValidation()
        {
            RuleFor(e => e.Name).MaximumLength(DbSettings.HashTag.Name.Length).Required(DbSettings.HashTag.Name.Required, "Adsız etiket mi olur hammmına");
        }
    }
}
