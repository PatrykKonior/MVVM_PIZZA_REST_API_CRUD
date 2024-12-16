using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PracownicyController : ControllerBase
    {
        private readonly IPracownicyService _pracownicyService;

        public PracownicyController(IPracownicyService pracownicyService)
        {
            _pracownicyService = pracownicyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pracownicy>>> GetAllPracownicy()
        {
            Console.WriteLine("Wywołano GetAllPracownicy"); // Debugowanie
            var pracownicy = await _pracownicyService.GetAllPracownicy();
            Console.WriteLine($"Znaleziono {pracownicy.Count()} pracowników"); // Sprawdzanie wyników
            return Ok(pracownicy);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pracownicy>> GetPracownikById(int id)
        {
            var pracownik = await _pracownicyService.GetPracownikById(id);
            if (pracownik == null) return NotFound();
            return Ok(pracownik);
        }

        [HttpPost]
        public async Task<ActionResult<Pracownicy>> CreatePracownik(Pracownicy pracownik)
        {
            var createdPracownik = await _pracownicyService.CreatePracownik(pracownik);
            return CreatedAtAction(nameof(GetPracownikById), new { id = createdPracownik.PracownikID }, createdPracownik);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pracownicy>> UpdatePracownik(int id, Pracownicy pracownik)
        {
            var updatedPracownik = await _pracownicyService.UpdatePracownik(id, pracownik);
            if (updatedPracownik == null) return NotFound();
            return Ok(updatedPracownik);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePracownik(int id)
        {
            var success = await _pracownicyService.DeletePracownik(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
