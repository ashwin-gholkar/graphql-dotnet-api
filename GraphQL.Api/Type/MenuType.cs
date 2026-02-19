using GraphQL.Types;
using GraphQLApiProject.Model;

namespace GraphQLApi.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType()
        {
            Field(x => x.Id).Description("The ID of the menu.");
            Field(x => x.Name).Description("The name of the menu.");
            Field(x => x.Description).Description("The description of the menu.");
            Field(x => x.Price).Description("The price of the menu.");
            Field(x => x.ImageUrl).Description("The image URL of the menu.");
            Field(x => x.CategoryId).Description("The category of the menu.");
        }
    }
}