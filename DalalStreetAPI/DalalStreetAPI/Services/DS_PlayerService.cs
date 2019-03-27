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

        public DS_PlayerService(DS_Context context)
        {
            _context = context;
        }

        public Task AddPlayer(DS_Player player)
        {
            _context.Add(player);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<IEnumerable<DS_Player>> GetAllPlayers()
        {
            IEnumerable<DS_Player> player = _context.DS_Player.AsEnumerable();
            return Task.FromResult(player);
        }

        public Task<DS_Player> GetPlayer(int Id)
        {
            var player = _context.DS_Player.FirstOrDefault(m => m.Id == Id);

            return Task.FromResult(player);
        }

        public Task SellAllPlayerStocks()
        {
            return Task.CompletedTask;
        }

        public Task<bool> SellStocks(TransactionModel obj)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<bool> BuyStocks(TransactionModel obj)
        {
            return Task.FromResult<bool>(true);
        }
    }
}
