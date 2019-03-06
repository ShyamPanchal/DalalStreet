using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DalalStreetAPI.Models;

namespace DalalStreetAPI.Services
{
    public class DS_CompanyCategoryService : IDS_CompanyCategoryService
    {
        private readonly DS_Context _context;
        private readonly ConcurrentDictionary<int, DS_CompanyCategory> _products = new ConcurrentDictionary<int, DS_CompanyCategory>();

        public DS_CompanyCategoryService(DS_Context context)
        {
            _context = context;
            foreach (var a in context.DS_CompanyCategory)
            {
                _products.TryAdd(a.Id, a);
            }
        }

        public Task AddAsync(DS_CompanyCategory record)
        {
            _context.Add(record);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddRecordAsync(IEnumerable<DS_CompanyCategory> records)
        {
            foreach (var record in records)
            {
                _context.Add(record);
            }
            return Task.CompletedTask;
        }

        public Task<DS_CompanyCategory> FindAsync(int id)
        {
            var record = _context.DS_CompanyCategory.FirstOrDefault(m => m.Id == id);

            return Task.FromResult(record);
        }

        public Task<IEnumerable<DS_CompanyCategory>> GetAllAsync()
        {
            IEnumerable<DS_CompanyCategory> record = _context.DS_CompanyCategory.AsEnumerable();
            return Task.FromResult(record);
        }

        public Task<DS_CompanyCategory> RemoveAsync(int id)
        {
            var record = _context.DS_CompanyCategory.Find(id);
            _context.DS_CompanyCategory.Remove(record);
            _context.SaveChanges();

            return Task.FromResult(record);
        }

        public Task UpdateAsync(DS_CompanyCategory record)
        {
            var beforeUpdate = _context.DS_CompanyCategory.Single(s => s.Id == record.Id);

            beforeUpdate.Name = record.Name;

            _context.DS_CompanyCategory.Update(beforeUpdate);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
