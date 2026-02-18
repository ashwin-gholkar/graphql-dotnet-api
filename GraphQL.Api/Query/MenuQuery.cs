using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Type;

namespace GraphQL.Api.Query
{
    public class MenuQuery : ObjectGraphType
    {

        public MenuQuery(IMenuRepository menuRepository)
        {
            Field<ListGraphType<MenuType>>(
               "menus").Resolve(context =>
               {
                   return menuRepository.GetAllMenus();
               });

            Field<MenuType>(
                "menu")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "MenuId" }))
                .Resolve(context =>
               {
                   var menuId = context.GetArgument<int>("MenuId");
                   return menuRepository.GetMenuById(menuId);
               });

        }
    }
}