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
        public async Task<ActionResult<IEnumerable<FakturaDto>>> GetAllFaktury()
        {
            var faktury = await _fakturyService.GetAllFaktury();
            var fakturyDto = faktury.Select(f => new FakturaDto
            {
                FakturaID = f.FakturaID,
                ZamówienieID = f.ZamówienieID,
                DataWystawienia = f.DataWystawienia,
                WystawionaNa = f.WystawionaNa,
                OpisDotyczy = f.OpisDotyczy,
                KwotaNetto = f.KwotaNetto,
                VAT = f.VAT,
                KwotaBrutto = f.KwotaBrutto
            });

            return Ok(fakturyDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FakturaDto>> GetFakturaById(int id)
        {
            var faktura = await _fakturyService.GetFakturaById(id);
            if (faktura == null)
            {
                return NotFound(new { message = "Faktura not found" });
            }

            var fakturaDto = new FakturaDto
            {
                FakturaID = faktura.FakturaID,
                ZamówienieID = faktura.ZamówienieID,
                DataWystawienia = faktura.DataWystawienia,
                WystawionaNa = faktura.WystawionaNa,
                OpisDotyczy = faktura.OpisDotyczy,
                KwotaNetto = faktura.KwotaNetto,
                VAT = faktura.VAT,
                KwotaBrutto = faktura.KwotaBrutto
            };

            return Ok(fakturaDto);
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