using Microsoft.EntityFrameworkCore;
using Okusana.Infrasructure.Contexts.PgContext;

namespace Okusana.API.Extensions
{
    static public class AddDbExtension
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
    }
}
