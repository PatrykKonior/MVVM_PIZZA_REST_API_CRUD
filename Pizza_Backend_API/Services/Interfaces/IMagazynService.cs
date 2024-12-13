﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Services.Interfaces
{
    public interface IMagazynService
    {
        Task<IEnumerable<Magazyn>> GetAllMagazyn();
        Task<Magazyn> GetMagazynById(int id);
        Task<Magazyn> CreateMagazyn(Magazyn magazyn);
        Task<Magazyn> UpdateMagazyn(int id, Magazyn magazyn);
        Task<bool> DeleteMagazyn(int id);
    }
}