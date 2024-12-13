using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class PrzepisyKulinarneService : IPrzepisyKulinarneService
    {
        private readonly PizzeriaContext _context;

        public PrzepisyKulinarneService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PrzepisyKulinarne>> GetAllPrzepisy()
        {
            return await _context.PrzepisyKulinarne.ToListAsync();
        }

        public async Task<PrzepisyKulinarne> GetPrzepisById(int id)
        {
            return await _context.PrzepisyKulinarne.FindAsync(id);
        }

        public async Task<PrzepisyKulinarne> CreatePrzepis(PrzepisyKulinarne przepis)
        {
            _context.PrzepisyKulinarne.Add(przepis);
            await _context.SaveChangesAsync();
            return przepis;
        }

        public async Task<PrzepisyKulinarne> UpdatePrzepis(int id, PrzepisyKulinarne przepis)
        {
            var existingPrzepis = await _context.PrzepisyKulinarne.FindAsync(id);
            if (existingPrzepis == null) return null;

            existingPrzepis.NazwaPrzepisu = przepis.NazwaPrzepisu;
            existingPrzepis.Składniki = przepis.Składniki;
            existingPrzepis.InstrukcjaPrzygotowania = przepis.InstrukcjaPrzygotowania;
            existingPrzepis.CzasPrzygotowania = przepis.CzasPrzygotowania;

            await _context.SaveChangesAsync();
            return existingPrzepis;
        }

        public async Task<bool> DeletePrzepis(int id)
        {
            var przepis = await _context.PrzepisyKulinarne.FindAsync(id);
            if (przepis == null) return false;

            _context.PrzepisyKulinarne.Remove(przepis);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}