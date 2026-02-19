using GraphQL;
using GraphQL.Api.Data;
using GraphQL.Api.Interfaces;
using GraphQL.Api.Mutation;
using GraphQL.Api.Query;
using GraphQL.Api.Schema;
using GraphQL.Api.Services;
using GraphQL.Api.Type;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Services;
using GraphQLApi.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();

//configure GraphQL
builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<CategoryType>();
builder.Services.AddTransient<ReservationType>();


builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<CategoryQuery>();
builder.Services.AddTransient<ReservationQuery>();
builder.Services.AddTransient<RootQuery>();

// builder.Services.AddTransient<MenuMutation>();
// builder.Services.AddTransient<MenuInputType>();

//configure sql server
builder.Services.AddDbContext<GraphQLDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("graphQlDbConnection"));
});
builder.Services.AddTransient<ISchema, RootSchema>();

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
app.UseGraphQLGraphiQL("/ui/graphiql", new GraphiQLOptions
{
    GraphQLEndPoint = "/graphql"
});

app.MapControllers();
app.Run();

