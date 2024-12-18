using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Services
{
    public class OpinieService : IOpinieService
    {
        private readonly PizzeriaContext _context;

        public OpinieService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Opinie>> GetAllOpinie()
        {
            return await _context.Opinie.ToListAsync();
        }

        public async Task<Opinie> GetOpiniaById(int id)
        {
            return await _context.Opinie.FindAsync(id);
        }

        public async Task<Opinie> CreateOpinia(Opinie opinia)
        {
            _context.Opinie.Add(opinia);
            await _context.SaveChangesAsync();
            return opinia;
        }

        public async Task<Opinie> UpdateOpinia(int id, Opinie opinia)
        {
            var existingOpinia = await _context.Opinie.FindAsync(id);
            if (existingOpinia == null) return null;

            existingOpinia.Opinia = opinia.Opinia;
            existingOpinia.Klient = opinia.Klient;

            await _context.SaveChangesAsync();
            return existingOpinia;
        }

        public async Task<bool> DeleteOpinia(int id)
        {
            var opinia = await _context.Opinie.FindAsync(id);
            if (opinia == null) return false;

            _context.Opinie.Remove(opinia);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}