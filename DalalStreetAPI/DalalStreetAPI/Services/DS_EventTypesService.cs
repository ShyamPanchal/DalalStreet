using DalalStreetAPI.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public class DS_EventTypesService : IDS_EventTypesService
    {
        private readonly DS_Context _context;
        private readonly ConcurrentDictionary<int, DS_EventTypes> _products = new ConcurrentDictionary<int, DS_EventTypes>();

        public DS_EventTypesService(DS_Context context)
        {
            _context = context;
            foreach (var a in context.DS_EventTypes)
            {
                _products.TryAdd(a.Id, a);
            }
        }

        public Task AddAsync(DS_EventTypes record)
        {
            _context.Add(record);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddRecordAsync(IEnumerable<DS_EventTypes> records)
        {
            foreach (var record in records)
            {
                _context.Add(record);
            }
            return Task.CompletedTask;
        }

        public Task<DS_EventTypes> FindAsync(int id)
        {
            var record = _context.DS_EventTypes.FirstOrDefault(m => m.Id == id);

            return Task.FromResult(record);
        }

        public Task<IEnumerable<DS_EventTypes>> GetAllAsync()
        {
            IEnumerable<DS_EventTypes> record = _context.DS_EventTypes.AsEnumerable();
            return Task.FromResult(record);
        }

        public Task<DS_EventTypes> RemoveAsync(int id)
        {
            var record = _context.DS_EventTypes.Find(id);
            _context.DS_EventTypes.Remove(record);
            _context.SaveChanges();

            return Task.FromResult(record);
        }

        public Task UpdateAsync(DS_EventTypes record)
        {
            var beforeUpdate = _context.DS_EventTypes.Single(s => s.Id == record.Id);

            beforeUpdate.Likelihood = record.Likelihood;
            beforeUpdate.TypeString = record.TypeString;
            beforeUpdate.EffectOnSelf = record.EffectOnSelf;
            beforeUpdate.EffectOnOthers = record.EffectOnOthers;

            _context.DS_EventTypes.Update(beforeUpdate);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
