using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpinieController : ControllerBase
    {
        private readonly IOpinieService _opinieService;

        public OpinieController(IOpinieService opinieService)
        {
            _opinieService = opinieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Opinie>>> GetAllOpinie()
        {
            var opinie = await _opinieService.GetAllOpinie();
            return Ok(opinie);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Opinie>> GetOpiniaById(int id)
        {
            var opinia = await _opinieService.GetOpiniaById(id);
            if (opinia == null) return NotFound();
            return Ok(opinia);
        }

        [HttpPost]
        public async Task<ActionResult<Opinie>> CreateOpinia(Opinie opinia)
        {
            var createdOpinia = await _opinieService.CreateOpinia(opinia);
            return CreatedAtAction(nameof(GetOpiniaById), new { id = createdOpinia.ID }, createdOpinia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Opinie>> UpdateOpinia(int id, Opinie opinia)
        {
            var updatedOpinia = await _opinieService.UpdateOpinia(id, opinia);
            if (updatedOpinia == null) return NotFound();
            return Ok(updatedOpinia);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOpinia(int id)
        {
            var success = await _opinieService.DeleteOpinia(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}