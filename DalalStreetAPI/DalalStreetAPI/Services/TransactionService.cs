using DalalStreetAPI.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public class TransactionService: ITransactionService
    {
        private readonly DS_Context _context;
        private readonly ConcurrentDictionary<int, TransactionLogs> _logs = new ConcurrentDictionary<int, TransactionLogs>();

        public TransactionService(DS_Context context)
        {
            _context = context;
            foreach (var a in context.TransactionLogs)
            {
                _logs.TryAdd(a.Id, a);
            }
        }

        public Task AddAsync(TransactionLogs record)
        {
            _context.Add(record);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddRecordAsync(IEnumerable<TransactionLogs> records)
        {
            foreach (var record in records)
            {
                _context.Add(record);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TransactionLogs>> GetAllAsync()
        {
            IEnumerable<TransactionLogs> record = _context.TransactionLogs.AsEnumerable();
            return Task.FromResult(record);
        }
    }
}
