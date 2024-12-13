using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZamówieniaController : ControllerBase
    {
        private readonly IZamówieniaService _zamówieniaService;

        public ZamówieniaController(IZamówieniaService zamówieniaService)
        {
            _zamówieniaService = zamówieniaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zamówienia>>> GetAllZamówienia()
        {
            var zamówienia = await _zamówieniaService.GetAllZamówienia();
            return Ok(zamówienia);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zamówienia>> GetZamówienieById(int id)
        {
            var zamówienie = await _zamówieniaService.GetZamówienieById(id);
            if (zamówienie == null) return NotFound();
            return Ok(zamówienie);
        }

        [HttpPost]
        public async Task<ActionResult<Zamówienia>> CreateZamówienie(Zamówienia zamówienie)
        {
            var createdZamówienie = await _zamówieniaService.CreateZamówienie(zamówienie);
            return CreatedAtAction(nameof(GetZamówienieById), new { id = createdZamówienie.ZamówienieID }, createdZamówienie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Zamówienia>> UpdateZamówienie(int id, Zamówienia zamówienie)
        {
            var updatedZamówienie = await _zamówieniaService.UpdateZamówienie(id, zamówienie);
            if (updatedZamówienie == null) return NotFound();
            return Ok(updatedZamówienie);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteZamówienie(int id)
        {
            var success = await _zamówieniaService.DeleteZamówienie(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
