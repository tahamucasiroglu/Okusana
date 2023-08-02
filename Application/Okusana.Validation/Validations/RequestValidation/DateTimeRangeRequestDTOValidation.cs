using FluentValidation;
using Okusana.DTOs.Concrete.Request;
using Okusana.Extensions;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.RequestValidation
{
    public class DateTimeRangeRequestDTOValidation : AbstractValidator<DateTimeRangeRequestDTO>
    {
        public DateTimeRangeRequestDTOValidation()
        {
            RuleFor(e => e.StartDate).Must(e => e.IsLessThan(DateTime.Now)).WithMessage("Gelecekten mi okuyacan").Required(true, "Tarih yok");
            RuleFor(e => e.EndDate).Must(e => e.IsLessThan(DateTime.Now)).WithMessage("Gelecekten mi okuyacan").Required(true, "Tarih yok");
        }
    }
}
