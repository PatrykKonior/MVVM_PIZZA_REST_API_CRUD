using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZamówieniaFirmoweController : ControllerBase
    {
        private readonly IZamówieniaFirmoweService _zamówieniaFirmoweService;

        public ZamówieniaFirmoweController(IZamówieniaFirmoweService zamówieniaFirmoweService)
        {
            _zamówieniaFirmoweService = zamówieniaFirmoweService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZamówieniaFirmowe>>> GetAllZamówieniaFirmowe()
        {
            var zamówieniaFirmowe = await _zamówieniaFirmoweService.GetAllZamówieniaFirmowe();
            return Ok(zamówieniaFirmowe);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZamówieniaFirmowe>> GetZamówienieFirmoweById(int id)
        {
            var zamówienieFirmowe = await _zamówieniaFirmoweService.GetZamówienieFirmoweById(id);
            if (zamówienieFirmowe == null) return NotFound();
            return Ok(zamówienieFirmowe);
        }

        [HttpPost]
        public async Task<ActionResult<ZamówieniaFirmowe>> CreateZamówienieFirmowe(ZamówieniaFirmowe zamówienieFirmowe)
        {
            var createdZamówienieFirmowe = await _zamówieniaFirmoweService.CreateZamówienieFirmowe(zamówienieFirmowe);
            return CreatedAtAction(nameof(GetZamówienieFirmoweById), new { id = createdZamówienieFirmowe.ZamówienieFirmoweID }, createdZamówienieFirmowe);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ZamówieniaFirmowe>> UpdateZamówienieFirmowe(int id, ZamówieniaFirmowe zamówienieFirmowe)
        {
            var updatedZamówienieFirmowe = await _zamówieniaFirmoweService.UpdateZamówienieFirmowe(id, zamówienieFirmowe);
            if (updatedZamówienieFirmowe == null) return NotFound();
            return Ok(updatedZamówienieFirmowe);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteZamówienieFirmowe(int id)
        {
            var success = await _zamówieniaFirmoweService.DeleteZamówienieFirmowe(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
