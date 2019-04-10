using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DalalStreetAPI.Models;

namespace DalalStreetAPI.Services
{
    public interface IDS_NewsEventService
    {
        #region DS_NewsEvent
        Task AddAsync(DS_NewsEvent record);
        Task AddRecordAsync(IEnumerable<DS_NewsEvent> records);
        Task<DS_NewsEvent> RemoveAsync(int id);
        Task<IEnumerable<DS_NewsEvent>> GetAllAsync(int count);
        Task<DS_NewsEvent> FindAsync(int id);
        Task UpdateAsync(DS_NewsEvent record);
        #endregion
    }
}
