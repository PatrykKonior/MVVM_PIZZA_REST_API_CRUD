using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Models.Entities;
using PizzeriaAPI.Services.Interfaces;

namespace PizzeriaAPI.Services
{
    public class PracownicyService : IPracownicyService
    {
        private readonly PizzeriaContext _context;

        public PracownicyService(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pracownicy>> GetAllPracownicy()
        {
            return await _context.Pracownicy.ToListAsync();
        }

        public async Task<Pracownicy> GetPracownikById(int id)
        {
            return await _context.Pracownicy.FindAsync(id);
        }

        public async Task<Pracownicy> CreatePracownik(Pracownicy pracownik)
        {
            _context.Pracownicy.Add(pracownik);
            await _context.SaveChangesAsync();
            return pracownik;
        }

        public async Task<Pracownicy> UpdatePracownik(int id, Pracownicy pracownik)
        {
            var existingPracownik = await _context.Pracownicy.FindAsync(id);
            if (existingPracownik == null) return null;

            existingPracownik.Imię = pracownik.Imię;
            existingPracownik.Nazwisko = pracownik.Nazwisko;
            existingPracownik.Stanowisko = pracownik.Stanowisko;
            existingPracownik.Telefon = pracownik.Telefon;
            existingPracownik.Email = pracownik.Email;
            existingPracownik.DataZatrudnienia = pracownik.DataZatrudnienia;
            existingPracownik.Wynagrodzenie = pracownik.Wynagrodzenie;

            await _context.SaveChangesAsync();
            return existingPracownik;
        }

        public async Task<bool> DeletePracownik(int id)
        {
            var pracownik = await _context.Pracownicy.FindAsync(id);
            if (pracownik == null) return false;

            _context.Pracownicy.Remove(pracownik);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
