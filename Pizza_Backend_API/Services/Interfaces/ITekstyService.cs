using PizzeriaAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface ITekstyService
    {
        Task<IEnumerable<Teksty>> GetAllTeksty();
        Task<Teksty> GetTekstById(int id);
        Task<Teksty> CreateTekst(Teksty tekst);
        Task<Teksty> UpdateTekst(int id, Teksty tekst);
        Task<bool> DeleteTekst(int id);
    }
}