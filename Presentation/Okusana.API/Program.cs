using Okusana.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddDb();
builder.AddDependencyInjections();
builder.AddScoped();
builder.AddSingleton();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.RestartDb();
app.AddDataToCategory();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

for (int i = 0; i < 10; i++) Console.WriteLine(Guid.NewGuid());

app.UseAuthorization();

app.MapControllers();

app.Run();
