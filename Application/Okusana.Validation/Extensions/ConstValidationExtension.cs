using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Extensions
{
    static public class ConstValidationExtension
    {
        static public IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilderOptions<T, TProperty> validation, string? message = null)
            => message == null ? validation.NotEmpty().NotNull() : validation.NotEmpty().NotNull().WithMessage(message);
        static public IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilderInitial<T, TProperty> validation, string? message = null)
            => message == null ? validation.NotNull().NotEmpty() : validation.NotEmpty().NotNull().WithMessage(message);

        static public IRuleBuilderOptions<T, TProperty> IsGuid<T, TProperty>(this IRuleBuilderOptions<T, TProperty> validation, string? message = null)
            => message == null ? validation.Must(e => e?.ToString()?.Length == 32) : validation.Must(e => e?.ToString()?.Length == 32).WithMessage(message);
        static public IRuleBuilderOptions<T, TProperty> IsGuid<T, TProperty>(this IRuleBuilderInitial<T, TProperty> validation, string? message = null)
            => message == null ? validation.Must(e => e?.ToString()?.Length == 32) : validation.Must(e => e?.ToString()?.Length == 32).WithMessage(message);




    }
}

