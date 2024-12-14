using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IUżytkownicyService
    {
        Task<IEnumerable<Użytkownicy>> GetAllUżytkownicy();
        Task<Użytkownicy> GetUżytkownikById(int id);
        Task<Użytkownicy> CreateUżytkownik(Użytkownicy użytkownik);
        Task<Użytkownicy> UpdateUżytkownik(int id, Użytkownicy użytkownik);
        Task<bool> DeleteUżytkownik(int id);
        Task<bool> VerifyLogin(string loginRequestLogin, string loginRequestPassword);
    }
}