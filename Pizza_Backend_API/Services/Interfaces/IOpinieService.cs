using PizzeriaAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IOpinieService
    {
        Task<IEnumerable<Opinie>> GetAllOpinie();
        Task<Opinie> GetOpiniaById(int id);
        Task<Opinie> CreateOpinia(Opinie opinia);
        Task<Opinie> UpdateOpinia(int id, Opinie opinia);
        Task<bool> DeleteOpinia(int id);
    }
}