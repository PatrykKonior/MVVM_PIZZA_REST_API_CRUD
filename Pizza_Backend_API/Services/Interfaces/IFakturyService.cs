using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IFakturyService
    {
        Task<IEnumerable<Faktury>> GetAllFaktury();
        Task<Faktury> GetFakturaById(int id);
        Task<Faktury> CreateFaktura(Faktury faktura);
        Task<Faktury> UpdateFaktura(int id, Faktury faktura);
        Task<bool> DeleteFaktura(int id);
    }
}