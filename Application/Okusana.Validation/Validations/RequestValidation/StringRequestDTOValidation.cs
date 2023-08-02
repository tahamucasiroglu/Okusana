using FluentValidation;
using Okusana.DTOs.Concrete.Request;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.RequestValidation
{
    public class StringRequestDTOValidation : AbstractValidator<StringRequestDTO>
    {
        public StringRequestDTOValidation()
        {
            RuleFor(e => e.Value).Required(true, "Değer Gerekli");
        }
    }
}
