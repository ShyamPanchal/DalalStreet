using DalalStreetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public interface IDS_Service
    {
        #region DS_Company
        Task AddAsync(DS_Company record);
        Task AddRecordAsync(IEnumerable<DS_Company> records);
        Task<DS_Company> RemoveAsync(int id);
        Task<IEnumerable<DS_Company>> GetAllAsync();
        Task<DS_Company> FindAsync(int id);
        Task UpdateAsync(DS_Company record);
        #endregion
    }
}
