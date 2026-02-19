using GraphQL.Api.Data;
using GraphQL.Api.Interfaces;
using GraphQL.Api.Model;

namespace GraphQL.Api.Services
{
        
    public class CategoryRepository(GraphQLDbContext graphQLDbContext) : ICategoryRepository
    {
            private readonly GraphQLDbContext _graphQLDbContext = graphQLDbContext;
        public Category AddCategory(Category category)
        {
            _graphQLDbContext.Add(category);
             _graphQLDbContext.SaveChanges();
            return category;
        }

        public bool DeleteCategory(int id)
        {
             var existingCategory = _graphQLDbContext.Categories.Find(id);
            if (existingCategory != null)
            {
                _graphQLDbContext.Categories.Remove(existingCategory);
                _graphQLDbContext.SaveChanges(); 
                return true;
            }
            return false;
        }

        public List<Category> GetAllCategories()
        {
           return _graphQLDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
             return  _graphQLDbContext.Categories.FirstOrDefault(m => m.Id == id);
        }

        public Category UpdateCategory(int id, Category category)
        {
             var existingCategory = _graphQLDbContext.Categories.Find(id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.ImageUrl = category.ImageUrl;
                _graphQLDbContext.SaveChanges(); 
                return category;
            }
            throw new ArgumentException("category not found");
        }
    }
}