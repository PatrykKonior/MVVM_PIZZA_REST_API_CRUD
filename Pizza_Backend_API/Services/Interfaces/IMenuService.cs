using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenus();
        Task<Menu> GetMenuById(int id);
        Task<Menu> CreateMenu(Menu menu);
        Task<Menu> UpdateMenu(int id, Menu menu);
        Task<bool> DeleteMenu(int id);
    }
}