using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Model;

namespace GraphQL.Api.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category AddCategory(Category menu);
        Category UpdateCategory(int id, Category menu);
        bool DeleteCategory(int id);
    }
}