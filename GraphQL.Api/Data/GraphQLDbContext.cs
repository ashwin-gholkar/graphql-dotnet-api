using GraphQL.Api.Model;
using GraphQLApiProject.Model;
using Microsoft.EntityFrameworkCore;


namespace GraphQL.Api.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Menu>().HasData(
                  new Menu
                  {
                      Id = 1,
                      Name = "Margherita Pizza",
                      Description = "Classic pizza with tomato sauce, mozzarella, and basil",
                      Price = 12.99
                  },

    new Menu
    {
        Id = 2,
        Name = "Veggie Burger",
        Description = "Grilled vegetable patty with lettuce, tomato, and cheese",
        Price = 9.49
    },

    new Menu
    {
        Id = 3,
        Name = "Chicken Biryani",
        Description = "Spiced basmati rice with tender chicken pieces",
        Price = 14.75
    },

    new Menu
    {
        Id = 4,
        Name = "Pasta Alfredo",
        Description = "Creamy white sauce pasta with parmesan cheese",
        Price = 11.25
    },

    new Menu
    {
        Id = 5,
        Name = "Caesar Salad",
        Description = "Fresh romaine lettuce with Caesar dressing and croutons",
        Price = 8.60
    }

            );
        }
    }
}