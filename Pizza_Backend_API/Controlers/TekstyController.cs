using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TekstyController : ControllerBase
    {
        private readonly ITekstyService _tekstyService;

        public TekstyController(ITekstyService tekstyService)
        {
            _tekstyService = tekstyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teksty>>> GetAllTeksty()
        {
            var teksty = await _tekstyService.GetAllTeksty();
            return Ok(teksty);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teksty>> GetTekstById(int id)
        {
            var tekst = await _tekstyService.GetTekstById(id);
            if (tekst == null) return NotFound();
            return Ok(tekst);
        }

        [HttpPost]
        public async Task<ActionResult<Teksty>> CreateTekst(Teksty tekst)
        {
            var createdTekst = await _tekstyService.CreateTekst(tekst);
            return CreatedAtAction(nameof(GetTekstById), new { id = createdTekst.ID }, createdTekst);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Teksty>> UpdateTekst(int id, Teksty tekst)
        {
            var updatedTekst = await _tekstyService.UpdateTekst(id, tekst);
            if (updatedTekst == null) return NotFound();
            return Ok(updatedTekst);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTekst(int id)
        {
            var success = await _tekstyService.DeleteTekst(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}