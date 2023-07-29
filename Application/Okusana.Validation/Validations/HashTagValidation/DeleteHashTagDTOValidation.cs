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
    public class DeleteHashTagDTOValidation : AbstractValidator<DeleteHashTagDTO>
    {
        public DeleteHashTagDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
        }
    }
}
