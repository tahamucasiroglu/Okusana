using FluentValidation;
using Okusana.Constants;


namespace Okusana.Validation.Extensions
{
    static public class ValidationExtension
    {
        static public IRuleBuilderOptions<T, Guid> IdValidation<T>(this IRuleBuilderInitial<T, Guid> validation)
            => validation.Required(true, "Id Yok").IsGuid(DbSettings.NonGuidMessage);

        static public IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilderOptions<T, TProperty> validation, bool IsRequired, string? message = null)
            => !IsRequired ? throw new Exception("Veritabanındaki zorunluluk kalttı fluent içinde kaldır") : message == null ? validation.NotEmpty().NotNull() : validation.NotEmpty().NotNull().WithMessage(message);
        static public IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilderInitial<T, TProperty> validation, bool IsRequired, string? message = null)
            => !IsRequired ? throw new Exception("Veritabanındaki zorunluluk kalttı fluent içinde kaldır") : message == null ? validation.NotNull().NotEmpty() : validation.NotEmpty().NotNull().WithMessage(message);

        static public IRuleBuilderOptions<T, TProperty> IsGuid<T, TProperty>(this IRuleBuilderOptions<T, TProperty> validation, string? message = null)
            => message == null ? validation.Must(e => e?.ToString()?.Length == 32) : validation.Must(e => e?.ToString()?.Length == 32).WithMessage(message);
        static public IRuleBuilderOptions<T, TProperty> IsGuid<T, TProperty>(this IRuleBuilderInitial<T, TProperty> validation, string? message = null)
            => message == null ? validation.Must(e => e?.ToString()?.Length == 32) : validation.Must(e => e?.ToString()?.Length == 32).WithMessage(message);


        

    }
}

