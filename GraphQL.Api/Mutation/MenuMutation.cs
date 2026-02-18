using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Type;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Type;
using GraphQLApiProject.Model;

namespace GraphQL.Api.Mutation
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenuRepository menuRepository)
        {
            Field<MenuType>(
                "CreateMenu")
                .Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }))
                .Resolve(context =>
               {
                   var menu = context.GetArgument<Menu>("menu");
                   return menuRepository.AddMenu(menu);
               });

            Field<MenuType>(
           "DeleteMenu")
           .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "MenuId" },
           new QueryArgument<MenuInputType> { Name = "menu" }))
           .Resolve(context =>
          {
              var menu = context.GetArgument<Menu>("menu");
              var menuId = context.GetArgument<int>("MenuId");
              return menuRepository.UpdateMenu(menuId, menu);
          });


            Field<MenuType>(
             "UpdateMenu")
             .Arguments(
             new QueryArgument<MenuInputType> { Name = "MenuId" })
             .Resolve(context =>
            {
                var menuId = context.GetArgument<int>("MenuId");
                menuRepository.DeleteMenu(menuId);
                return "This menu with id " + menuId + " has been deleted.";
            });
        }
    }
}