using Microsoft.EntityFrameworkCore;
using Okusana.Constants;
using Okusana.Entities.Concrete;
using Okusana.Infrasructure.Contexts.PgContext;

namespace Okusana.API.Extensions
{
    static public class DbExtension
    {
        public static void AddDb(this WebApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString("OkusanaPgString");
            builder.Services.AddDbContext<OkusanaPgContext>(opt =>
            {
                opt.UseNpgsql(connectionString);
                opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel(LogLevel.Warning); //açılıştaki bir sürü konsol çıktısını önlemek için
                }));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        static public async Task RestartDb(this WebApplication builder)
        {
            using (var context = builder.Services.CreateScope().ServiceProvider.GetRequiredService<OkusanaPgContext>())
            {
                if (context.Database.CanConnect())
                {
                    Console.WriteLine("Database Siliniyor");
                    await context.Database.EnsureDeletedAsync();
                    Console.WriteLine("Database Slindi");
                    Console.WriteLine("Database Üretiliyor");
                    await context.Database.EnsureCreatedAsync();
                    Console.WriteLine("Database Üretildi");
                }
            }
        }

        static async public Task SeedDb(this WebApplication builder, int Size = 1)
        {
            if (Size < 1) { Size = 1; }
            using (var context = builder.Services.CreateScope().ServiceProvider.GetRequiredService<OkusanaPgContext>())
            {
                if (context.Database.CanConnect())
                {
                    #region Categories
                    List<Category> categories = new List<Category>();
                    for (int i = 0; i < 10 * Size; i++)
                    {
                        categories.Add(new Category() { Id = Guid.NewGuid(), Name = $"Category - {i}" });
                    }
                    await context.Categories.AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                    #endregion

                    #region SubCategories
                    List<SubCategory> subCategories = new List<SubCategory>();
                    foreach (var category in categories)
                    {
                        for (int i = 0; i < 5 * Size; i++)
                        {
                            subCategories.Add(new SubCategory() { Id = Guid.NewGuid(), Name = $"Sub Category - {i} <-> {category.Name}", CategoryId = category.Id });
                        }
                    }
                    await context.SubCategories.AddRangeAsync(subCategories);
                    await context.SaveChangesAsync();
                    #endregion

                    #region HashTags
                    List<HashTag> hashTags = new List<HashTag>();
                    for (int i = 0; i < 50 * Size; i++)
                    {
                        hashTags.Add(new HashTag() { Id = Guid.NewGuid(), Name = $"Hashtag {i}" });
                    }
                    await context.HashTags.AddRangeAsync(hashTags);
                    await context.SaveChangesAsync();
                    #endregion

                    #region Users
                    List<User> users = new List<User>();
                    for (int i = 0; i < 10 * Size; i++)
                    {
                        users.Add(new User() { Id = Guid.NewGuid(), Name = $"Name{i}", Surname = $"Surname{i}", Email = $"Email{i}", BirthDate = DateTime.UtcNow.AddYears(30), Gender = false, Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", Status = UserStatus.Admin });
                    }
                    await context.Users.AddRangeAsync(users);
                    await context.SaveChangesAsync();
                    #endregion

                    #region Blogs
                    List<Blog> blogs = new List<Blog>();
                    for (int i = 0; i < 30 * Size; i++)
                    {
                        blogs.Add(new Blog() { Id = Guid.NewGuid(), UserId = users[new Random().Next(users.Count - 1)].Id, SubCategoryId = subCategories[new Random().Next(subCategories.Count-1)].Id, Title = $"Title{i}", Content = $"Content{i}", PublicationDate = null, IsPublished = true });
                    }
                    await context.Blogs.AddRangeAsync(blogs);
                    await context.SaveChangesAsync();
                    #endregion

                    #region BlogTags
                    List<BlogTag> blogTags = new List<BlogTag>();
                    foreach (Blog blog in blogs)
                    {
                        for (int i = 0; i < 5 * Size; i++)
                        {
                            blogTags.Add(new BlogTag() { Id = Guid.NewGuid(), BlogId = blog.Id, TagId = hashTags[new Random().Next(hashTags.Count - 1)].Id });
                        }
                    }
                    await context.BlogTags.AddRangeAsync(blogTags);
                    await context.SaveChangesAsync();
                    #endregion

                    #region Comments
                    List<Comment> comments = new List<Comment>();
                    foreach (Blog blog in blogs)
                    {
                        for (int i = 0; i < 5 * Size; i++)
                        {
                            comments.Add(new Comment() { Id = Guid.NewGuid(), BlogId = blog.Id, UserId = users[new Random().Next(users.Count - 1)].Id, Content = $"Content{i}", Rate = new Random().Next(5) });
                        }
                    }
                    await context.Comments.AddRangeAsync(comments);
                    await context.SaveChangesAsync();
                    #endregion

                }
            }
        }

    }
}
