using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.User;
using Okusana.Extensions;
using Okusana.Validation.Extensions;


namespace Okusana.Validation.Validations.UserValidation
{
    public class AddUserDTOValidation : AbstractValidator<AddUserDTO>
    {
        public AddUserDTOValidation()
        {
            RuleFor(e => e.Name).MaximumLength(DbSettings.User.Name.Length).Required(DbSettings.User.Name.Required, "adı yok mu lan bunun");
            RuleFor(e => e.Surname).MaximumLength(DbSettings.User.Surname.Length).Required(DbSettings.User.Surname.Required, "soyadı yok mu lan bunun");
            RuleFor(e => e.Email).MaximumLength(DbSettings.User.Email.Length).Required(DbSettings.User.Email.Required, "mail ne mail");
            RuleFor(e => e.Phone).MaximumLength(DbSettings.User.Phone.Length).Must(e => e == null || e.IsPhoneNumber());
            RuleFor(e => e.IdentityNumber).MaximumLength(DbSettings.User.Identity.Length).Must(e => e == null || e.IsIdentityNumber());
            RuleFor(e => e.BirthDate).Must(e => e.IsLessThan(DateTime.Now)).WithMessage("Doğduğun gibi mi geldin aq");
            RuleFor(e => e.Password).MaximumLength(DbSettings.User.Password.Length).MinimumLength(DbSettings.User.Password.Length - 1 ); //64 olmalı ondan böyle yaptım
            RuleFor(e => e.Name).MaximumLength(DbSettings.User.Status.Length).Required(DbSettings.User.Status.Required, "rütbe ne la bunun");
        }
    }
}
