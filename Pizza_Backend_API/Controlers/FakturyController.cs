using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FakturyController : ControllerBase
    {
        private readonly IFakturyService _fakturyService;

        public FakturyController(IFakturyService fakturyService)
        {
            _fakturyService = fakturyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faktury>>> GetAllFaktury()
        {
            var faktury = await _fakturyService.GetAllFaktury();
            return Ok(faktury);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Faktury>> GetFakturaById(int id)
        {
            var faktura = await _fakturyService.GetFakturaById(id);
            if (faktura == null) return NotFound();
            return Ok(faktura);
        }

        [HttpPost]
        public async Task<ActionResult<Faktury>> CreateFaktura(Faktury faktura)
        {
            var createdFaktura = await _fakturyService.CreateFaktura(faktura);
            return CreatedAtAction(nameof(GetFakturaById), new { id = createdFaktura.FakturaID }, createdFaktura);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Faktury>> UpdateFaktura(int id, Faktury faktura)
        {
            var updatedFaktura = await _fakturyService.UpdateFaktura(id, faktura);
            if (updatedFaktura == null) return NotFound();
            return Ok(updatedFaktura);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFaktura(int id)
        {
            var success = await _fakturyService.DeleteFaktura(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}