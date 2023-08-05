using Okusana.API.Attributes;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Models.HateoasModel;

namespace Okusana.API.Extensions
{
    static public class SingletonExtension
    {
        public static void AddSingleton(this WebApplicationBuilder builder)
        {
            builder.AddHateoas();
            builder.Services.AddSingleton<LogConnectionAttribute>();
        }

        private static void AddHateoas(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IBlogHateoas, Hateoas.Blog>();
            builder.Services.AddSingleton<IBlogTagHateoas, Hateoas.BlogTag>();
            builder.Services.AddSingleton<ICategoryHateoas, Hateoas.Category>();
            builder.Services.AddSingleton<ICommentHateoas, Hateoas.Comment>();
            builder.Services.AddSingleton<IHashTagHateoas, Hateoas.HashTag>();
            builder.Services.AddSingleton<ISubCategoryHateoas, Hateoas.SubCategory>();
            builder.Services.AddSingleton<IUserHateoas, Hateoas.User>();
        }


    }
}
