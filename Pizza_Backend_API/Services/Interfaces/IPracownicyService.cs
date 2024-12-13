using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IPracownicyService
    {
        Task<IEnumerable<Pracownicy>> GetAllPracownicy();
        Task<Pracownicy> GetPracownikById(int id);
        Task<Pracownicy> CreatePracownik(Pracownicy pracownik);
        Task<Pracownicy> UpdatePracownik(int id, Pracownicy pracownik);
        Task<bool> DeletePracownik(int id);
    }
}