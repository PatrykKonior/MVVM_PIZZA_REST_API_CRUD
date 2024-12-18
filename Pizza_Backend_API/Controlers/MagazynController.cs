using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using PizzeriaAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MagazynController : ControllerBase
    {
        private readonly IMagazynService _magazynService;
        private readonly PizzeriaContext _context;

        public MagazynController(IMagazynService magazynService, PizzeriaContext context)
        {
            _magazynService = magazynService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazynDto>>> GetAllMagazyn()
        {
            var magazyn = await _magazynService.GetAllMagazyn();
            return Ok(magazyn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MagazynDto>> GetMagazynById(int id)
        {
            var magazyn = await _magazynService.GetMagazynById(id);
            if (magazyn == null) return NotFound();
            return Ok(magazyn);
        }

        [HttpPost]
        public async Task<ActionResult<Magazyn>> CreateMagazyn([FromBody] Magazyn magazyn)
        {
            // Walidacja klucza obcego TowarID
            var towarExists = await _context.Towary.AnyAsync(t => t.TowarID == magazyn.TowarID);
            if (!towarExists)
            {
                return BadRequest(new { message = "Podany TowarID nie istnieje." });
            }

            var createdMagazyn = await _magazynService.CreateMagazyn(magazyn);
            return CreatedAtAction(nameof(GetMagazynById), new { id = createdMagazyn.MagazynID }, createdMagazyn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Magazyn>> UpdateMagazyn(int id, [FromBody] Magazyn magazyn)
        {
            // Walidacja klucza obcego TowarID
            var towarExists = await _context.Towary.AnyAsync(t => t.TowarID == magazyn.TowarID);
            if (!towarExists)
            {
                return BadRequest(new { message = "Podany TowarID nie istnieje." });
            }

            var updatedMagazyn = await _magazynService.UpdateMagazyn(id, magazyn);
            if (updatedMagazyn == null) return NotFound();
            return Ok(updatedMagazyn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMagazyn(int id)
        {
            var success = await _magazynService.DeleteMagazyn(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}