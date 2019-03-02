using DalalStreetAPI.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public class DS_Service : IDS_Service
    {
        private readonly DS_Context _context;
        private readonly ConcurrentDictionary<int, DS_Company> _products = new ConcurrentDictionary<int, DS_Company>();

        public DS_Service(DS_Context context)
        {
            _context = context;
            foreach (var a in context.DS_Company)
            {
                _products.TryAdd(a.Id, a);
            }
        }

        public Task AddAsync(DS_Company record)
        {
            _context.Add(record);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddRecordAsync(IEnumerable<DS_Company> records)
        {
            foreach (var record in records)
            {
                _context.Add(record);
            }
            return Task.CompletedTask;
        }

        public Task<DS_Company> FindAsync(int id)
        {
            var record = _context.DS_Company.FirstOrDefault(m => m.Id == id);

            return Task.FromResult(record);
        }

        public Task<IEnumerable<DS_Company>> GetAllAsync()
        {
            IEnumerable<DS_Company> record = _context.DS_Company.AsEnumerable();
            return Task.FromResult(record);
        }

        public Task<DS_Company> RemoveAsync(int id)
        {
            var record = _context.DS_Company.Find(id);
            _context.DS_Company.Remove(record);
            _context.SaveChanges();

            return Task.FromResult(record);
        }

        public Task UpdateAsync(DS_Company record)
        {
            var beforeUpdate = _context.DS_Company.Single(s => s.Id == record.Id);

            beforeUpdate.stockValues = record.stockValues;
            beforeUpdate.Name = record.Name;

            _context.DS_Company.Update(beforeUpdate);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
