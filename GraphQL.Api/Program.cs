using GraphQL;
using GraphQL.Api.Mutation;
using GraphQL.Api.Query;
using GraphQL.Api.Schema;
using GraphQL.Api.Type;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Services;
using GraphQLApi.Type;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();

//configure GraphQL
builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<MenuMutation>();
builder.Services.AddTransient<MenuInputType>();


builder.Services.AddTransient<ISchema, MenuSchema>();

//enable support for graphql
builder.Services.AddGraphQL(options =>
{
    options.AddAutoSchema<ISchema>().AddSystemTextJson();
});

var app = builder.Build();



app.UseHttpsRedirection();

app.UseGraphQL("/graphql");
app.UseGraphQL<ISchema>();

app.MapControllers();
app.Run();

