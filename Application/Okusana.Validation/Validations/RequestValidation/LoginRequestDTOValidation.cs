using FluentValidation;
using Okusana.DTOs.Concrete.Request;
using Okusana.Validation.Extensions;

namespace Okusana.Validation.Validations.RequestValidation
{
    public class LoginRequestDTOValidation : AbstractValidator<LoginRequestDTO>
    {
        public LoginRequestDTOValidation()
        {
            RuleFor(e => e.Email).Required(true, "mail adressiz nere giriyon").EmailAddress().WithMessage("Mail adresi geçersiz");
            RuleFor(e => e.Password).Required(true, "şifresiz girersin ama nereye").Length(64).WithMessage("Şifre istenen uzunlukta değil ");
        }
    }
}
