using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface ITowaryService
    {
        Task<IEnumerable<Towary>> GetAllTowary();
        Task<Towary> GetTowarById(int id);
        Task<Towary> CreateTowar(Towary towar);
        Task<Towary> UpdateTowar(int id, Towary towar);
        Task<bool> DeleteTowar(int id);
    }
}