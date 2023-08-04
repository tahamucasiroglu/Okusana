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
    public class PageRequestDTOValidation : AbstractValidator<PageRequestDTO>
    {
        public PageRequestDTOValidation()
        {
            RuleFor(e => e.PageCount).Required(true, "Sayfa Numarası zorunlu").GreaterThan(0).WithMessage("Negatif sayfa numarası olmaz");
            RuleFor(e => e.PageSize).GreaterThan(5).WithMessage("sayfa item sayısı 5 ten büyük olmalı");
        }
    }
}
