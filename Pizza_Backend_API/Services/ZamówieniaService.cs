using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class ZamówieniaService : IZamówieniaService
    {
        private readonly PizzeriaContext _context;

        public ZamówieniaService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zamówienia>> GetAllZamówienia()
        {
            return await _context.Zamówienia.ToListAsync();
        }

        public async Task<Zamówienia> GetZamówienieById(int id)
        {
            return await _context.Zamówienia.FindAsync(id);
        }

        public async Task<Zamówienia> CreateZamówienie(Zamówienia zamówienie)
        {
            _context.Zamówienia.Add(zamówienie);
            await _context.SaveChangesAsync();
            return zamówienie;
        }

        public async Task<Zamówienia> UpdateZamówienie(int id, Zamówienia zamówienie)
        {
            var existingZamówienie = await _context.Zamówienia.FindAsync(id);
            if (existingZamówienie == null) return null;

            existingZamówienie.UżytkownikID = zamówienie.UżytkownikID;
            existingZamówienie.DataZamówienia = zamówienie.DataZamówienia;
            existingZamówienie.Status = zamówienie.Status;
            existingZamówienie.KwotaCałkowita = zamówienie.KwotaCałkowita;

            await _context.SaveChangesAsync();
            return existingZamówienie;
        }

        public async Task<bool> DeleteZamówienie(int id)
        {
            var zamówienie = await _context.Zamówienia.FindAsync(id);
            if (zamówienie == null) return false;

            _context.Zamówienia.Remove(zamówienie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}