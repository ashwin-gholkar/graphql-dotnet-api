using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLApi.Interfaces;
using GraphQLApiProject.Model;

namespace GraphQLApi.Services
{
    public class MenuRepository : IMenuRepository
    {
        private static List<Menu> _menus = new List<Menu>()
        {
            new Menu() { Id = 1, Name = "Classic Burger", Description="A juicy chicken burger with lettuce and cheese" , Price = 8.99},
            new Menu() { Id = 2, Name = "Margherita Pizza", Description = "Tomato, mozzarella, and basil pizza", Price = 10.50 },
            new Menu() { Id = 3, Name = "Grilled Chicken Salad", Description = "Fresh garden salad with grilled chicken", Price = 7.95 },
            new Menu() { Id = 4, Name = "Pasta Alfredo", Description = "Creamy Alfredo sauce with fettuccine pasta", Price = 12.75 },
            new Menu() { Id = 5, Name = "Chocolate Brownie Sundae", Description = "Warm chocolate brownie with ice cream and fudge", Price = 6.99 },

        };
        public Menu AddMenu(Menu menu)
        {
            menu.Id = _menus.Max(m => m.Id) + 1;
            _menus.Add(menu);
            return menu;
        }

        public bool DeleteMenu(int id)
        {
            var menu = _menus.FirstOrDefault(m => m.Id == id);
            if (menu != null)
            {
                _menus.Remove(menu);
                return true;
            }
            return false;
        }

        public List<Menu> GetAllMenus()
        {
            return _menus;
        }

        public Menu GetMenuById(int id)
        {
            return _menus.FirstOrDefault(m => m.Id == id);
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var existingMenu = _menus.FirstOrDefault(m => m.Id == id);
            if (existingMenu != null)
            {
                _menus.Remove(existingMenu);
                menu.Id = id;
                _menus.Add(menu);
                return menu;
            }
            throw new ArgumentException("Menu not found");
        }
    }
}