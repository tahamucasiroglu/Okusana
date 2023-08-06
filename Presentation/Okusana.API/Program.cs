using Okusana.API.Extensions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddCookies(); //Extension
        builder.AddPolicy(); //Extension
        builder.AddJWT(); //Extension
        builder.AddDb(); //Extension
        builder.AddDependencyInjections(); //Extension
        builder.AddScoped(); //Extension
        builder.AddSingleton(); //Extension
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthentication();

        var app = builder.Build();

        app.UsePathBase("/");


        await app.RestartDb(); //Extension
        await app.SeedDb(); //Extension
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}