using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class UżytkownicyService : IUżytkownicyService
    {
        private readonly PizzeriaContext _context;

        public UżytkownicyService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Użytkownicy>> GetAllUżytkownicy()
        {
            return await _context.Użytkownicy.ToListAsync();
        }

        public async Task<Użytkownicy> GetUżytkownikById(int id)
        {
            return await _context.Użytkownicy.FindAsync(id);
        }

        public async Task<Użytkownicy> CreateUżytkownik(Użytkownicy użytkownik)
        {
            _context.Użytkownicy.Add(użytkownik);
            await _context.SaveChangesAsync();
            return użytkownik;
        }

        public async Task<Użytkownicy> UpdateUżytkownik(int id, Użytkownicy użytkownik)
        {
            var existingUżytkownik = await _context.Użytkownicy.FindAsync(id);
            if (existingUżytkownik == null) return null;

            existingUżytkownik.Imię = użytkownik.Imię;
            existingUżytkownik.Nazwisko = użytkownik.Nazwisko;
            existingUżytkownik.Login = użytkownik.Login;
            existingUżytkownik.HasłoHash = użytkownik.HasłoHash;
            existingUżytkownik.Email = użytkownik.Email;
            existingUżytkownik.PoziomDostępu = użytkownik.PoziomDostępu;
            existingUżytkownik.DataRejestracji = użytkownik.DataRejestracji;

            await _context.SaveChangesAsync();
            return existingUżytkownik;
        }

        public async Task<bool> DeleteUżytkownik(int id)
        {
            var użytkownik = await _context.Użytkownicy.FindAsync(id);
            if (użytkownik == null) return false;

            _context.Użytkownicy.Remove(użytkownik);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
