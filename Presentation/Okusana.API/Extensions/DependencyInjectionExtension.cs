using FluentValidation;
using Okusana.Abstract.Service.Base;
using Okusana.Mapper.MapProfile;
using System.Reflection;

namespace Okusana.API.Extensions
{
    static public class DependencyInjectionExtension
    {
        static public void AddDependencyInjections(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MapProfile));

            builder.Services.AddFluentValidationValidators(Assembly.GetExecutingAssembly());

        }

        private static void AddFluentValidationValidators(this IServiceCollection services, Assembly assembly)
        {
            IEnumerable<Type> validatorTypes = assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && t.BaseType != null && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

            foreach (Type validatorType in validatorTypes)
            {
                Type? genericType = validatorType.BaseType?.GetGenericArguments().First();
                if (genericType != null)
                services.AddTransient(typeof(IValidator<>).MakeGenericType(genericType), validatorType);
            }
        }
    }
}
