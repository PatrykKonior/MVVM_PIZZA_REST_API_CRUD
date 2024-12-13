using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IKontaktService
    {
        Task<IEnumerable<Kontakt>> GetAllKontakt();
        Task<Kontakt> GetKontaktById(int id);
        Task<Kontakt> CreateKontakt(Kontakt kontakt);
        Task<Kontakt> UpdateKontakt(int id, Kontakt kontakt);
        Task<bool> DeleteKontakt(int id);
    }
}