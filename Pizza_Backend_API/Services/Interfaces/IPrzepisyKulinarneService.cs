using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IPrzepisyKulinarneService
    {
        Task<IEnumerable<PrzepisyKulinarne>> GetAllPrzepisy();
        Task<PrzepisyKulinarne> GetPrzepisById(int id);
        Task<PrzepisyKulinarne> CreatePrzepis(PrzepisyKulinarne przepis);
        Task<PrzepisyKulinarne> UpdatePrzepis(int id, PrzepisyKulinarne przepis);
        Task<bool> DeletePrzepis(int id);
    }
}