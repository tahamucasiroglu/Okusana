using Okusana.Abstract.Repository;
using Okusana.Abstract.Service;
using Okusana.DbService.Concrete;
using Okusana.Infrasructure.Repository.EfCore;

namespace Okusana.API.Extensions
{
    static public class AddScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {

            builder.Services.AddScoped<IBlogRepository, EfBlogRepository>();
            builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
            builder.Services.AddScoped<IHashTagRepository, EfHashTagRepository>();
            builder.Services.AddScoped<ISubCategoryRepository, EfSubCategoryRepository>();
            builder.Services.AddScoped<IUserRepository, EfUserRepository>();

            builder.Services.AddScoped<IBlogService, BlogService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IHashTagService, HashTagService>();
            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
            builder.Services.AddScoped<IUserService, UserService>();


        }
    }
}
