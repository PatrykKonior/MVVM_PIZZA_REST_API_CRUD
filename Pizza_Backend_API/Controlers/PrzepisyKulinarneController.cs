using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrzepisyKulinarneController : ControllerBase
    {
        private readonly IPrzepisyKulinarneService _przepisyService;

        public PrzepisyKulinarneController(IPrzepisyKulinarneService przepisyService)
        {
            _przepisyService = przepisyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrzepisyKulinarne>>> GetAllPrzepisy()
        {
            var przepisy = await _przepisyService.GetAllPrzepisy();
            return Ok(przepisy);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrzepisyKulinarne>> GetPrzepisById(int id)
        {
            var przepis = await _przepisyService.GetPrzepisById(id);
            if (przepis == null) return NotFound();
            return Ok(przepis);
        }

        [HttpPost]
        public async Task<ActionResult<PrzepisyKulinarne>> CreatePrzepis(PrzepisyKulinarne przepis)
        {
            var createdPrzepis = await _przepisyService.CreatePrzepis(przepis);
            return CreatedAtAction(nameof(GetPrzepisById), new { id = createdPrzepis.PrzepisID }, createdPrzepis);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PrzepisyKulinarne>> UpdatePrzepis(int id, PrzepisyKulinarne przepis)
        {
            var updatedPrzepis = await _przepisyService.UpdatePrzepis(id, przepis);
            if (updatedPrzepis == null) return NotFound();
            return Ok(updatedPrzepis);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePrzepis(int id)
        {
            var success = await _przepisyService.DeletePrzepis(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}