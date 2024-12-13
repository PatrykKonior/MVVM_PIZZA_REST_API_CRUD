using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class TowaryService : ITowaryService
    {
        private readonly PizzeriaContext _context;

        public TowaryService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Towary>> GetAllTowary()
        {
            return await _context.Towary.ToListAsync();
        }

        public async Task<Towary> GetTowarById(int id)
        {
            return await _context.Towary.FindAsync(id);
        }

        public async Task<Towary> CreateTowar(Towary towar)
        {
            _context.Towary.Add(towar);
            await _context.SaveChangesAsync();
            return towar;
        }

        public async Task<Towary> UpdateTowar(int id, Towary towar)
        {
            var existingTowar = await _context.Towary.FindAsync(id);
            if (existingTowar == null) return null;

            existingTowar.Nazwa = towar.Nazwa;
            existingTowar.Opis = towar.Opis;
            existingTowar.CenaZakupu = towar.CenaZakupu;
            existingTowar.CenaSprzedaży = towar.CenaSprzedaży;
            existingTowar.DataDodania = towar.DataDodania;

            await _context.SaveChangesAsync();
            return existingTowar;
        }

        public async Task<bool> DeleteTowar(int id)
        {
            var towar = await _context.Towary.FindAsync(id);
            if (towar == null) return false;

            _context.Towary.Remove(towar);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}