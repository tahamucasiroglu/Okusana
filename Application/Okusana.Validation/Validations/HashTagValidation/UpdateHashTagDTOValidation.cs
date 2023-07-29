using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.HashTag;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.HashTagValidation
{
    public class UpdateHashTagDTOValidation : AbstractValidator<UpdateHashTagDTO>
    {
        public UpdateHashTagDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
            RuleFor(e => e.Name).MaximumLength(DbSettings.HashTag.Name.Length).Required(DbSettings.HashTag.Name.Required, "Adsız etiket mi olur hammmına");
        }
    }
}
