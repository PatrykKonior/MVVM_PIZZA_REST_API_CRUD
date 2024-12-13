using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class MenuService : IMenuService
    {
        private readonly PizzeriaContext _context;

        public MenuService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetAllMenus()
        {
            return await _context.Menu.ToListAsync();
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await _context.Menu.FindAsync(id);
        }

        public async Task<Menu> CreateMenu(Menu menu)
        {
            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<Menu> UpdateMenu(int id, Menu menu)
        {
            var existingMenu = await _context.Menu.FindAsync(id);
            if (existingMenu == null) return null;

            existingMenu.Nazwa = menu.Nazwa;
            existingMenu.Opis = menu.Opis;
            existingMenu.Składniki = menu.Składniki;
            existingMenu.Cena = menu.Cena;
            existingMenu.Dostępność = menu.Dostępność;

            await _context.SaveChangesAsync();
            return existingMenu;
        }

        public async Task<bool> DeleteMenu(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
            if (menu == null) return false;

            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}