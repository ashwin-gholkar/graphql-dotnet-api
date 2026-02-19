using GraphQLApiProject.Model;

namespace GraphQL.Api.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; } 
        //one to many relationship
        public ICollection<Menu>  Menus { get; set; }
    }
}