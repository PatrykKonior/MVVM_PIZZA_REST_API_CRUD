using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MagazynController : ControllerBase
    {
        private readonly IMagazynService _magazynService;

        public MagazynController(IMagazynService magazynService)
        {
            _magazynService = magazynService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magazyn>>> GetAllMagazyn()
        {
            var magazyn = await _magazynService.GetAllMagazyn();
            return Ok(magazyn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Magazyn>> GetMagazynById(int id)
        {
            var magazyn = await _magazynService.GetMagazynById(id);
            if (magazyn == null) return NotFound();
            return Ok(magazyn);
        }

        [HttpPost]
        public async Task<ActionResult<Magazyn>> CreateMagazyn(Magazyn magazyn)
        {
            var createdMagazyn = await _magazynService.CreateMagazyn(magazyn);
            return CreatedAtAction(nameof(GetMagazynById), new { id = createdMagazyn.MagazynID }, createdMagazyn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Magazyn>> UpdateMagazyn(int id, Magazyn magazyn)
        {
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