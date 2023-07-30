using Okusana.API.Attributes;
using Okusana.API.Models.HateoasModel;

namespace Okusana.API.Extensions
{
    static public class AddSingletonExtension
    {
        public static void AddSingleton(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<Hateoas>();
            builder.Services.AddSingleton<LogConnectionAttribute>();
        }
    }
}
