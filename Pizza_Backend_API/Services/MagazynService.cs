using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class MagazynService : IMagazynService
    {
        private readonly PizzeriaContext _context;

        public MagazynService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Magazyn>> GetAllMagazyn()
        {
            return await _context.Magazyn.Include(m => m.TowarID).ToListAsync();
        }

        public async Task<Magazyn> GetMagazynById(int id)
        {
            return await _context.Magazyn.FindAsync(id);
        }

        public async Task<Magazyn> CreateMagazyn(Magazyn magazyn)
        {
            _context.Magazyn.Add(magazyn);
            await _context.SaveChangesAsync();
            return magazyn;
        }

        public async Task<Magazyn> UpdateMagazyn(int id, Magazyn magazyn)
        {
            var existingMagazyn = await _context.Magazyn.FindAsync(id);
            if (existingMagazyn == null) return null;

            existingMagazyn.TowarID = magazyn.TowarID;
            existingMagazyn.Ilość = magazyn.Ilość;
            existingMagazyn.Lokalizacja = magazyn.Lokalizacja;

            await _context.SaveChangesAsync();
            return existingMagazyn;
        }

        public async Task<bool> DeleteMagazyn(int id)
        {
            var magazyn = await _context.Magazyn.FindAsync(id);
            if (magazyn == null) return false;

            _context.Magazyn.Remove(magazyn);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}