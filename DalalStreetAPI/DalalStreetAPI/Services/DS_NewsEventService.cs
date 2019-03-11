using DalalStreetAPI.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public class DS_NewsEventService : IDS_NewsEventService
    {
        private readonly DS_Context _context;
        private readonly ConcurrentDictionary<int, DS_NewsEvent> _products = new ConcurrentDictionary<int, DS_NewsEvent>();

        public DS_NewsEventService(DS_Context context)
        {
            _context = context;
            foreach (var a in context.DS_NewsEvent)
            {
                _products.TryAdd(a.Id, a);
            }
        }

        public Task AddAsync(DS_NewsEvent record)
        {
            _context.Add(record);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddRecordAsync(IEnumerable<DS_NewsEvent> records)
        {
            foreach (var record in records)
            {
                _context.Add(record);
            }
            return Task.CompletedTask;
        }

        public Task<DS_NewsEvent> FindAsync(int id)
        {
            var record = _context.DS_NewsEvent.FirstOrDefault(m => m.Id == id);

            return Task.FromResult(record);
        }

        public Task<IEnumerable<DS_NewsEvent>> GetAllAsync()
        {
            IEnumerable<DS_NewsEvent> record = _context.DS_NewsEvent.AsEnumerable();
            return Task.FromResult(record);
        }

        public Task<DS_NewsEvent> RemoveAsync(int id)
        {
            var record = _context.DS_NewsEvent.Find(id);
            _context.DS_NewsEvent.Remove(record);
            _context.SaveChanges();

            return Task.FromResult(record);
        }

        public Task UpdateAsync(DS_NewsEvent record)
        {
            var beforeUpdate = _context.DS_NewsEvent.Single(s => s.Id == record.Id);

            beforeUpdate.OnCompanyId = record.OnCompanyId;
            beforeUpdate.EventTypeId = record.EventTypeId;

            _context.DS_NewsEvent.Update(beforeUpdate);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
