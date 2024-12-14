using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UżytkownicyController : ControllerBase
    {
        private readonly IUżytkownicyService _użytkownicyService;

        public UżytkownicyController(IUżytkownicyService użytkownicyService)
        {
            _użytkownicyService = użytkownicyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Użytkownicy>>> GetAllUżytkownicy()
        {
            var użytkownicy = await _użytkownicyService.GetAllUżytkownicy();
            return Ok(użytkownicy);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Użytkownicy>> GetUżytkownikById(int id)
        {
            var użytkownik = await _użytkownicyService.GetUżytkownikById(id);
            if (użytkownik == null) return NotFound();
            return Ok(użytkownik);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> VerifyLogin([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Login) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Login i hasło są wymagane.");
            }

            var isValidUser = await _użytkownicyService.VerifyLogin(loginRequest.Login, loginRequest.Password);

            if (isValidUser)
            {
                return Ok("Zalogowano pomyślnie!");
            }
            else
            {
                return Unauthorized("Niepoprawny login lub hasło.");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Użytkownicy>> CreateUżytkownik(Użytkownicy użytkownik)
        {
            var createdUżytkownik = await _użytkownicyService.CreateUżytkownik(użytkownik);
            return CreatedAtAction(nameof(GetUżytkownikById), new { id = createdUżytkownik.UżytkownikID }, createdUżytkownik);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Użytkownicy>> UpdateUżytkownik(int id, Użytkownicy użytkownik)
        {
            var updatedUżytkownik = await _użytkownicyService.UpdateUżytkownik(id, użytkownik);
            if (updatedUżytkownik == null) return NotFound();
            return Ok(updatedUżytkownik);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUżytkownik(int id)
        {
            var success = await _użytkownicyService.DeleteUżytkownik(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
