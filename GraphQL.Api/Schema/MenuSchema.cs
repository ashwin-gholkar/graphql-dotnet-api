using GraphQL.Api.Mutation;
using GraphQL.Api.Query;

namespace GraphQL.Api.Schema
{
    public class MenuSchema : GraphQL.Types.Schema
    {
        public MenuSchema(MenuQuery menuQuery, MenuMutation menuMutation)
        {
            Query = menuQuery;
            Mutation = menuMutation;
        }
    }
}