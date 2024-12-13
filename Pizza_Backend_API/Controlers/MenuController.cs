using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetAllMenus()
        {
            var menus = await _menuService.GetAllMenus();
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenuById(int id)
        {
            var menu = await _menuService.GetMenuById(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> CreateMenu(Menu menu)
        {
            var createdMenu = await _menuService.CreateMenu(menu);
            return CreatedAtAction(nameof(GetMenuById), new { id = createdMenu.MenuID }, createdMenu);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Menu>> UpdateMenu(int id, Menu menu)
        {
            var updatedMenu = await _menuService.UpdateMenu(id, menu);
            if (updatedMenu == null) return NotFound();
            return Ok(updatedMenu);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMenu(int id)
        {
            var success = await _menuService.DeleteMenu(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}