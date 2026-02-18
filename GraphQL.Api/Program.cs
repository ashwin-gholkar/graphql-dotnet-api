using GraphQLApi.Interfaces;
using GraphQLApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();

var app = builder.Build();



app.UseHttpsRedirection();


app.MapControllers();
app.Run();

