using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DalalStreetAPI.Models;

namespace DalalStreetAPI.Services
{
    public interface IDS_EventTypesService
    {
        #region DS_EventTypes
        Task AddAsync(DS_EventTypes record);
        Task AddRecordAsync(IEnumerable<DS_EventTypes> records);
        Task<DS_EventTypes> RemoveAsync(int id);
        Task<IEnumerable<DS_EventTypes>> GetAllAsync();
        Task<DS_EventTypes> FindAsync(int id);
        Task UpdateAsync(DS_EventTypes record);
        #endregion
    }
}
