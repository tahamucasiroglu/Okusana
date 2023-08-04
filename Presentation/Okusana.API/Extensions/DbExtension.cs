using Microsoft.EntityFrameworkCore;
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

        static public void RestartDb(this WebApplication builder)
        {
            using (var context = builder.Services.CreateScope().ServiceProvider.GetRequiredService<OkusanaPgContext>())
            {
                if (context.Database.CanConnect())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            }
        }

        static public void AddDataToCategory(this WebApplication builder, int Count = 100)
        {
            using (var context = builder.Services.CreateScope().ServiceProvider.GetRequiredService<OkusanaPgContext>())
            {
                if (context.Database.CanConnect())
                {
                    for (int i = 0; i < Count; i++)
                    {
                        context.Add(new Category() { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = $"Category - {i}" });
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
