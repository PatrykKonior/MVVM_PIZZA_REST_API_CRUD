using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class ZamówieniaFirmoweService : IZamówieniaFirmoweService
    {
        private readonly PizzeriaContext _context;

        public ZamówieniaFirmoweService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ZamówieniaFirmowe>> GetAllZamówieniaFirmowe()
        {
            return await _context.ZamówieniaFirmowe.ToListAsync();
        }

        public async Task<ZamówieniaFirmowe> GetZamówienieFirmoweById(int id)
        {
            return await _context.ZamówieniaFirmowe.FindAsync(id);
        }

        public async Task<ZamówieniaFirmowe> CreateZamówienieFirmowe(ZamówieniaFirmowe zamówienieFirmowe)
        {
            _context.ZamówieniaFirmowe.Add(zamówienieFirmowe);
            await _context.SaveChangesAsync();
            return zamówienieFirmowe;
        }

        public async Task<ZamówieniaFirmowe> UpdateZamówienieFirmowe(int id, ZamówieniaFirmowe zamówienieFirmowe)
        {
            var existingZamówienieFirmowe = await _context.ZamówieniaFirmowe.FindAsync(id);
            if (existingZamówienieFirmowe == null) return null;

            existingZamówienieFirmowe.PracownikID = zamówienieFirmowe.PracownikID;
            existingZamówienieFirmowe.DataZamówienia = zamówienieFirmowe.DataZamówienia;
            existingZamówienieFirmowe.Opis = zamówienieFirmowe.Opis;
            existingZamówienieFirmowe.Status = zamówienieFirmowe.Status;

            await _context.SaveChangesAsync();
            return existingZamówienieFirmowe;
        }

        public async Task<bool> DeleteZamówienieFirmowe(int id)
        {
            var zamówienieFirmowe = await _context.ZamówieniaFirmowe.FindAsync(id);
            if (zamówienieFirmowe == null) return false;

            _context.ZamówieniaFirmowe.Remove(zamówienieFirmowe);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
