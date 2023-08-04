using Microsoft.EntityFrameworkCore;
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

        static public void RestartDb(this IServiceProvider services)
        {
            using (var context = services.CreateScope().ServiceProvider.GetRequiredService<OkusanaPgContext>())
            {
                if (context.Database.CanConnect())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}
