using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Model;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Type;

namespace GraphQL.Api.Type
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IMenuRepository menuRepository)
        {
            Field(x => x.Id).Description("The ID of the category.");
            Field(x => x.Name).Description("The name of the category.");
            Field<ListGraphType<MenuType>>(
                "Menus").Resolve(context =>
                {
                    var category = context.Source;
                    return menuRepository.GetAllMenus();
                }
            );
        }
    }
}