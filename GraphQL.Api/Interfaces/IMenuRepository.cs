using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLApiProject.Model;

namespace GraphQLApi.Interfaces
{
    public interface IMenuRepository
    {
        List<Menu> GetAllMenus();
        Menu GetMenuById(int id);
        Menu AddMenu(Menu menu);
        Menu UpdateMenu(int id, Menu menu);
        bool DeleteMenu(int id);
    }
}