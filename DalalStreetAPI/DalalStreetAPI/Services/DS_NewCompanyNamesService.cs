using DalalStreetAPI.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public class DS_NewCompanyNamesService : IDS_NewCompanyNamesService
    {
        private readonly DS_Context _context;
        private readonly ConcurrentDictionary<int, DS_NewCompanyNames> _products = new ConcurrentDictionary<int, DS_NewCompanyNames>();

        public DS_NewCompanyNamesService(DS_Context context)
        {
            _context = context;
            foreach (var a in context.DS_NewCompanyNames)
            {
                _products.TryAdd(a.Id, a);
            }
        }

        public Task AddAsync(DS_NewCompanyNames record)
        {
            _context.Add(record);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddRecordAsync(IEnumerable<DS_NewCompanyNames> records)
        {
            foreach (var record in records)
            {
                _context.Add(record);
            }
            return Task.CompletedTask;
        }

        public Task<DS_NewCompanyNames> FindAsync(int id)
        {
            var record = _context.DS_NewCompanyNames.FirstOrDefault(m => m.Id == id);

            return Task.FromResult(record);
        }

        public Task<IEnumerable<DS_NewCompanyNames>> GetAllAsync()
        {
            IEnumerable<DS_NewCompanyNames> record = _context.DS_NewCompanyNames.AsEnumerable();
            return Task.FromResult(record);
        }

        public Task<DS_NewCompanyNames> RemoveAsync(int id)
        {
            var record = _context.DS_NewCompanyNames.Find(id);
            _context.DS_NewCompanyNames.Remove(record);
            _context.SaveChanges();

            return Task.FromResult(record);
        }

        public Task UpdateAsync(DS_NewCompanyNames record)
        {
            var beforeUpdate = _context.DS_NewCompanyNames.Single(s => s.Id == record.Id);

            beforeUpdate.Name = record.Name;

            _context.DS_NewCompanyNames.Update(beforeUpdate);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
