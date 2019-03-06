using DalalStreetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public interface IDS_CompanyCategoryService
    {
        #region DS_CompanyCategory
        Task AddAsync(DS_CompanyCategory record);
        Task AddRecordAsync(IEnumerable<DS_CompanyCategory> records);
        Task<DS_CompanyCategory> RemoveAsync(int id);
        Task<IEnumerable<DS_CompanyCategory>> GetAllAsync();
        Task<DS_CompanyCategory> FindAsync(int id);
        Task UpdateAsync(DS_CompanyCategory record);
        #endregion
    }
}
