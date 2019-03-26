using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DalalStreetAPI.Models;
using DalalStreetAPI.Models.ViewModels;

namespace DalalStreetAPI.Services
{
    public class DS_PlayerService : IDS_PlayerService
    {
        private readonly DS_Context _context;
        private readonly ConcurrentDictionary<int, DS_Player> _products = new ConcurrentDictionary<int, DS_Player>();

        public DS_PlayerService(DS_Context context)
        {
            _context = context;
            foreach (var a in context.DS_Player)
            {
                _products.TryAdd(a.Id, a);
            }
        }

        public Task AddPlayer(DS_Player player)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BuyStocks(TransactionModel obj)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<IEnumerable<DS_Player>> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Task<DS_Player> GetPlayer(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SellAllPlayerStocks()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SellStocks(TransactionModel obj)
        {
            return Task.FromResult<bool>(true);
        }
    }
}
