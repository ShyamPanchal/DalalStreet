using DalalStreetAPI.Models;
using DalalStreetAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Services
{
    public interface IDS_PlayerService
    {
        #region Player Service
        Task AddPlayer(DS_Player player);
        Task<DS_Player> GetPlayer(int Id);

        Task<IEnumerable<DS_Player>> GetAllPlayers();

        Task<bool> BuyStocks(TransactionModel obj);

        Task<bool> SellStocks(TransactionModel obj);

        Task SellAllPlayerStocks();

        Task ResetGame();
        #endregion
    }
}
