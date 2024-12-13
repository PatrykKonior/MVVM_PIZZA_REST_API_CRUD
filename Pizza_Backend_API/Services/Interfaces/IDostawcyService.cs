using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IDostawcyService
    {
        Task<IEnumerable<Dostawcy>> GetAllDostawcy();
        Task<Dostawcy> GetDostawcaById(int id);
        Task<Dostawcy> CreateDostawca(Dostawcy dostawca);
        Task<Dostawcy> UpdateDostawca(int id, Dostawcy dostawca);
        Task<bool> DeleteDostawca(int id);
    }
}