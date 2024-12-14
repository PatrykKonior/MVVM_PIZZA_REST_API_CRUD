using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class KontaktService : IKontaktService
    {
        private readonly PizzeriaContext _context;

        public KontaktService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kontakt>> GetAllKontakt()
        {
            return await _context.Kontakt.ToListAsync();
        }

        public async Task<Kontakt> GetKontaktById(int id)
        {
            return await _context.Kontakt.FindAsync(id);
        }

        public async Task<Kontakt> CreateKontakt(Kontakt kontakt)
        {
            kontakt.DataDodania = DateTime.Now;
            _context.Kontakt.Add(kontakt);
            await _context.SaveChangesAsync();
            return kontakt;
        }

        public async Task<Kontakt> UpdateKontakt(int id, Kontakt kontakt)
        {
            var existingKontakt = await _context.Kontakt.FindAsync(id);
            if (existingKontakt == null) return null;

            existingKontakt.Imię = kontakt.Imię;
            existingKontakt.Email = kontakt.Email;
            existingKontakt.NumerTelefonu = kontakt.NumerTelefonu;
            existingKontakt.Wiadomość = kontakt.Wiadomość;
            existingKontakt.DataDodania = DateTime.Now;

            await _context.SaveChangesAsync();
            return existingKontakt;
        }

        public async Task<bool> DeleteKontakt(int id)
        {
            var kontakt = await _context.Kontakt.FindAsync(id);
            if (kontakt == null) return false;

            _context.Kontakt.Remove(kontakt);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}