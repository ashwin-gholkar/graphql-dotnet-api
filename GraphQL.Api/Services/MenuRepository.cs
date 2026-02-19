using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Api.Data;
using GraphQLApi.Interfaces;
using GraphQLApiProject.Model;

namespace GraphQLApi.Services
{
    public class MenuRepository(GraphQLDbContext graphQLDbContext) : IMenuRepository
    {
        private readonly GraphQLDbContext _graphQLDbContext = graphQLDbContext;

        public Menu AddMenu(Menu menu)
        {
             _graphQLDbContext.Add(menu);
             _graphQLDbContext.SaveChanges();
            return menu;
        }

        public bool DeleteMenu(int id)
        {
             var existingMenu = _graphQLDbContext.Menus.Find(id);
            if (existingMenu != null)
            {
                _graphQLDbContext.Menus.Remove(existingMenu);
                _graphQLDbContext.SaveChanges(); 
                return true;
            }
            return false;
        }

        public List<Menu> GetAllMenus()
        {
            return _graphQLDbContext.Menus.ToList();
        }

        public Menu GetMenuById(int id)
        {
            return  _graphQLDbContext.Menus.FirstOrDefault(m => m.Id == id);
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var existingMenu = _graphQLDbContext.Menus.Find(id);
            if (existingMenu != null)
            {
                existingMenu.Name = menu.Name;
                existingMenu.Price = menu.Price;
                existingMenu.Description = menu.Description;
                _graphQLDbContext.SaveChanges(); 
                return menu;
            }
            throw new ArgumentException("Menu not found");
        }
    }
}