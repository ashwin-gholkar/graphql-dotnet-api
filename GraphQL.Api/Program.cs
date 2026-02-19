using GraphQL;
using GraphQL.Api.Data;
using GraphQL.Api.Mutation;
using GraphQL.Api.Query;
using GraphQL.Api.Schema;
using GraphQL.Api.Type;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Services;
using GraphQLApi.Type;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Playground; 

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

//configure sql server
builder.Services.AddDbContext<GraphQLDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("graphQlDbConnection"));
});
builder.Services.AddTransient<ISchema, MenuSchema>();

//enable support for graphql
builder.Services.AddGraphQL(options =>
{
    options.AddAutoSchema<ISchema>().AddSystemTextJson();
});

var app = builder.Build();



app.UseHttpsRedirection();

// app.UseGraphQL("/graphql");
// app.UseGraphQL<ISchema>();
// GraphQL endpoint
app.UseGraphQL<ISchema>("/graphql");

// GraphQL Playground UI (note: no Path property)
app.UseGraphQLPlayground("/ui/playground", new PlaygroundOptions
{
    GraphQLEndPoint = "/graphql"
});

app.MapControllers();
app.Run();

 