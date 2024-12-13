using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KontaktController : ControllerBase
    {
        private readonly IKontaktService _kontaktService;

        public KontaktController(IKontaktService kontaktService)
        {
            _kontaktService = kontaktService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kontakt>>> GetAllKontakt()
        {
            var kontakt = await _kontaktService.GetAllKontakt();
            return Ok(kontakt);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kontakt>> GetKontaktById(int id)
        {
            var kontakt = await _kontaktService.GetKontaktById(id);
            if (kontakt == null) return NotFound();
            return Ok(kontakt);
        }

        [HttpPost]
        public async Task<ActionResult<Kontakt>> CreateKontakt(Kontakt kontakt)
        {
            var createdKontakt = await _kontaktService.CreateKontakt(kontakt);
            return CreatedAtAction(nameof(GetKontaktById), new { id = createdKontakt.KontaktID }, createdKontakt);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Kontakt>> UpdateKontakt(int id, Kontakt kontakt)
        {
            var updatedKontakt = await _kontaktService.UpdateKontakt(id, kontakt);
            if (updatedKontakt == null) return NotFound();
            return Ok(updatedKontakt);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKontakt(int id)
        {
            var success = await _kontaktService.DeleteKontakt(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}