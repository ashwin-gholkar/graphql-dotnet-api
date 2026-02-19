using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Interfaces;
using GraphQL.Api.Type;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Type;

namespace GraphQL.Api.Query
{
    public class CategoryQuery : ObjectGraphType
    {

        public CategoryQuery(ICategoryRepository categoryRepository)
        {
            Field<ListGraphType<CategoryType>>(
               "categories").Resolve(context =>
               {
                   return categoryRepository.GetAllCategories();
               });

            Field<CategoryType>(
                "category")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "CategoryId" }))
                .Resolve(context =>
               {
                   var categoryId = context.GetArgument<int>("CategoryId");
                   return categoryRepository.GetCategoryById(categoryId);
               });

        }
    }
}