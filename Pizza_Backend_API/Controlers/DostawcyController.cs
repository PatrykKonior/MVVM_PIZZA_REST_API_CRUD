using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DostawcyController : ControllerBase
    {
        private readonly IDostawcyService _dostawcyService;

        public DostawcyController(IDostawcyService dostawcyService)
        {
            _dostawcyService = dostawcyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dostawcy>>> GetAllDostawcy()
        {
            var dostawcy = await _dostawcyService.GetAllDostawcy();
            return Ok(dostawcy);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dostawcy>> GetDostawcaById(int id)
        {
            var dostawca = await _dostawcyService.GetDostawcaById(id);
            if (dostawca == null) return NotFound();
            return Ok(dostawca);
        }

        [HttpPost]
        public async Task<ActionResult<Dostawcy>> CreateDostawca(Dostawcy dostawca)
        {
            var createdDostawca = await _dostawcyService.CreateDostawca(dostawca);
            return CreatedAtAction(nameof(GetDostawcaById), new { id = createdDostawca.DostawcaID }, createdDostawca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Dostawcy>> UpdateDostawca(int id, Dostawcy dostawca)
        {
            var updatedDostawca = await _dostawcyService.UpdateDostawca(id, dostawca);
            if (updatedDostawca == null) return NotFound();
            return Ok(updatedDostawca);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDostawca(int id)
        {
            var success = await _dostawcyService.DeleteDostawca(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}