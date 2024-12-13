using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IZamówieniaService
    {
        Task<IEnumerable<Zamówienia>> GetAllZamówienia();
        Task<Zamówienia> GetZamówienieById(int id);
        Task<Zamówienia> CreateZamówienie(Zamówienia zamówienie);
        Task<Zamówienia> UpdateZamówienie(int id, Zamówienia zamówienie);
        Task<bool> DeleteZamówienie(int id);
    }
}