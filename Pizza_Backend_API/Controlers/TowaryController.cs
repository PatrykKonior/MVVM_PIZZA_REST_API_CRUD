using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TowaryController : ControllerBase
    {
        private readonly ITowaryService _towaryService;

        public TowaryController(ITowaryService towaryService)
        {
            _towaryService = towaryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Towary>>> GetAllTowary()
        {
            var towary = await _towaryService.GetAllTowary();
            return Ok(towary);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Towary>> GetTowarById(int id)
        {
            var towar = await _towaryService.GetTowarById(id);
            if (towar == null) return NotFound();
            return Ok(towar);
        }

        [HttpPost]
        public async Task<ActionResult<Towary>> CreateTowar(Towary towar)
        {
            var createdTowar = await _towaryService.CreateTowar(towar);
            return CreatedAtAction(nameof(GetTowarById), new { id = createdTowar.TowarID }, createdTowar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Towary>> UpdateTowar(int id, Towary towar)
        {
            var updatedTowar = await _towaryService.UpdateTowar(id, towar);
            if (updatedTowar == null) return NotFound();
            return Ok(updatedTowar);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTowar(int id)
        {
            var success = await _towaryService.DeleteTowar(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}