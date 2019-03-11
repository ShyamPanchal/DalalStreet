using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DalalStreetAPI.Models;

namespace DalalStreetAPI.Services
{
    public interface IDS_NewCompanyNamesService
    {
        #region DS_NewCompanyNames
        Task AddAsync(DS_NewCompanyNames record);
        Task AddRecordAsync(IEnumerable<DS_NewCompanyNames> records);
        Task<DS_NewCompanyNames> RemoveAsync(int id);
        Task<IEnumerable<DS_NewCompanyNames>> GetAllAsync();
        Task<DS_NewCompanyNames> FindAsync(int id);
        Task UpdateAsync(DS_NewCompanyNames record);
        #endregion
    }
}
