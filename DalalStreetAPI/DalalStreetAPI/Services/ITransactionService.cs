using DalalStreetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public interface ITransactionService
    {
        #region TransactionLogs
        Task AddAsync(TransactionLogs record);

        Task AddRecordAsync(IEnumerable<TransactionLogs> records);

        //Task<TransactionLogs> RemoveAsync(int id);

        Task<IEnumerable<TransactionLogs>> GetAllAsync();

        //Task<TransactionLogs> FindAsync(int id);

        //Task UpdateAsync(TransactionLogs record);
        #endregion
    }
}
