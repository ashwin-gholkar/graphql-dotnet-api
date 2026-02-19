using GraphQLApiProject.Model;
using Microsoft.EntityFrameworkCore;


namespace GraphQL.Api.Data
{
    public class GraphQLDbContext:DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }
        public DbSet<Menu> Menus { get; set; }
    }
}