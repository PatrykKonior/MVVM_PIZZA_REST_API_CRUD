using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IZamówieniaFirmoweService
    {
        Task<IEnumerable<ZamówieniaFirmowe>> GetAllZamówieniaFirmowe();
        Task<ZamówieniaFirmowe> GetZamówienieFirmoweById(int id);
        Task<ZamówieniaFirmowe> CreateZamówienieFirmowe(ZamówieniaFirmowe zamówienieFirmowe);
        Task<ZamówieniaFirmowe> UpdateZamówienieFirmowe(int id, ZamówieniaFirmowe zamówienieFirmowe);
        Task<bool> DeleteZamówienieFirmowe(int id);
    }
}