using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class DostawcyService : IDostawcyService
    {
        private readonly PizzeriaContext _context;

        public DostawcyService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dostawcy>> GetAllDostawcy()
        {
            return await _context.Dostawcy.ToListAsync();
        }

        public async Task<Dostawcy> GetDostawcaById(int id)
        {
            return await _context.Dostawcy.FindAsync(id);
        }

        public async Task<Dostawcy> CreateDostawca(Dostawcy dostawca)
        {
            _context.Dostawcy.Add(dostawca);
            await _context.SaveChangesAsync();
            return dostawca;
        }

        public async Task<Dostawcy> UpdateDostawca(int id, Dostawcy dostawca)
        {
            var existingDostawca = await _context.Dostawcy.FindAsync(id);
            if (existingDostawca == null) return null;

            existingDostawca.Nazwa = dostawca.Nazwa;
            existingDostawca.KontaktEmail = dostawca.KontaktEmail;
            existingDostawca.KontaktTelefon = dostawca.KontaktTelefon;
            existingDostawca.Adres = dostawca.Adres;
            existingDostawca.Miasto = dostawca.Miasto;
            existingDostawca.KodPocztowy = dostawca.KodPocztowy;
            existingDostawca.Kraj = dostawca.Kraj;

            await _context.SaveChangesAsync();
            return existingDostawca;
        }

        public async Task<bool> DeleteDostawca(int id)
        {
            var dostawca = await _context.Dostawcy.FindAsync(id);
            if (dostawca == null) return false;

            _context.Dostawcy.Remove(dostawca);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}