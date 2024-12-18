using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Services
{
    public class TekstyService : ITekstyService
    {
        private readonly PizzeriaContext _context;

        public TekstyService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teksty>> GetAllTeksty()
        {
            return await _context.Teksty.ToListAsync();
        }

        public async Task<Teksty> GetTekstById(int id)
        {
            return await _context.Teksty.FindAsync(id);
        }

        public async Task<Teksty> CreateTekst(Teksty tekst)
        {
            _context.Teksty.Add(tekst);
            await _context.SaveChangesAsync();
            return tekst;
        }

        public async Task<Teksty> UpdateTekst(int id, Teksty tekst)
        {
            var existingTekst = await _context.Teksty.FindAsync(id);
            if (existingTekst == null) return null;

            existingTekst.Title = tekst.Title;
            existingTekst.Content = tekst.Content;
            existingTekst.Section = tekst.Section;

            await _context.SaveChangesAsync();
            return existingTekst;
        }

        public async Task<bool> DeleteTekst(int id)
        {
            var tekst = await _context.Teksty.FindAsync(id);
            if (tekst == null) return false;

            _context.Teksty.Remove(tekst);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}