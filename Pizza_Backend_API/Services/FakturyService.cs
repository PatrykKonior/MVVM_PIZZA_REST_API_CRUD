using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class FakturyService : IFakturyService
    {
        private readonly PizzeriaContext _context;

        public FakturyService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Faktury>> GetAllFaktury()
        {
            return await _context.Faktury.Include(f => f.ZamówienieID).ToListAsync();
        }

        public async Task<Faktury> GetFakturaById(int id)
        {
            return await _context.Faktury.FindAsync(id);
        }

        public async Task<Faktury> CreateFaktura(Faktury faktura)
        {
            _context.Faktury.Add(faktura);
            await _context.SaveChangesAsync();
            return faktura;
        }

        public async Task<Faktury> UpdateFaktura(int id, Faktury faktura)
        {
            var existingFaktura = await _context.Faktury.FindAsync(id);
            if (existingFaktura == null) return null;

            existingFaktura.ZamówienieID = faktura.ZamówienieID;
            existingFaktura.DataWystawienia = faktura.DataWystawienia;
            existingFaktura.WystawionaNa = faktura.WystawionaNa;
            existingFaktura.OpisDotyczy = faktura.OpisDotyczy;
            existingFaktura.KwotaNetto = faktura.KwotaNetto;
            existingFaktura.VAT = faktura.VAT;
            existingFaktura.KwotaBrutto = faktura.KwotaBrutto;

            await _context.SaveChangesAsync();
            return existingFaktura;
        }

        public async Task<bool> DeleteFaktura(int id)
        {
            var faktura = await _context.Faktury.FindAsync(id);
            if (faktura == null) return false;

            _context.Faktury.Remove(faktura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
