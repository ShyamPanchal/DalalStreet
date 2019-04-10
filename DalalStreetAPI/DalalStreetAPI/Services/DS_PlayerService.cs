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
            var player = _context.DS_Player.FirstOrDefault(c => c.Id == Id);

            return Task.FromResult(player);
        }

        public async Task SellAllPlayerStocks()
        {
            var allPlayers = _context.DS_PlayerInventory.AsEnumerable();
            foreach (var player in allPlayers)
            {
                if (player.OwnedStocks > 0)
                {
                    TransactionModel obj = new TransactionModel();
                    obj.CompanyId = player.CompanyId;
                    obj.PlayerId = player.PlayerId;
                    obj.TotalStocks = player.OwnedStocks;

                    await SellStocks(obj);

                }
            }
        }

        public async Task<bool> SellStocks(TransactionModel obj)
        {
            // get related components
            DS_Player player = await GetPlayer(obj.PlayerId);
            DS_Company company = _context.DS_Company.FirstOrDefault(c => c.Id == obj.CompanyId);

            #region Check if transaction is possible
            if (player == null || company == null)
            {
                return false;
            }

            DS_PlayerInventory playerInventory = _context.DS_PlayerInventory.FirstOrDefault(c => (c.CompanyId == company.Id && c.PlayerId == player.Id));

            if (playerInventory == null)
            {
                return false;
            }

            if (playerInventory.OwnedStocks < obj.TotalStocks)
            {
                return false;
            }

            double stockCost = company.stockValues * obj.TotalStocks;
            #endregion

            #region Calculate transaction score

            long transactionScore = 0;

            double y = company.stockValues;
            int b = -2499;
            int m = 12500;

            double multiplier = (y - b) / m;

            transactionScore = (long)(stockCost * multiplier);

            #endregion

            #region Calculate New Stock Value for the Company

            double newStockValue = 0;

            int totalStocksAfterPurchase = company.totalStocks + obj.TotalStocks;

            int stockQuantityForCalculation = totalStocksAfterPurchase + obj.TotalStocks;

            double stockValueMultiplier = ((double)totalStocksAfterPurchase / stockQuantityForCalculation);

            newStockValue = company.stockValues * stockValueMultiplier;

            #endregion

            #region Deduct Number of Stocks with Stock Value

            company.stockValues = (int)newStockValue;
            company.totalStocks += obj.TotalStocks;

            #endregion

            #region Remove Stocks from user.

            playerInventory.OwnedStocks -= obj.TotalStocks;

            #endregion

            #region Update User

            player.Score += transactionScore;
            player.Balance += stockCost;

            #endregion

            #region Add to transaction logs.

            TransactionLogs log = new TransactionLogs();
            log.Transaction = $"[Buy Stock] [Player]:{player.Id}||[Company]{company.Id}||[Score]{transactionScore}||[Balance]{player.Balance}";

            #endregion

            #region Commit
            try
            {
                // Saving Company
                _context.DS_Company.Update(company);

                // Saving UserInventory
                _context.DS_PlayerInventory.Update(playerInventory);

                // Saving User
                _context.DS_Player.Update(player);

                // Saving Transaction
                _context.TransactionLogs.Add(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }

            // Commit
            _context.SaveChanges();

            #endregion

            return true;
        }

        public async Task<bool> BuyStocks(TransactionModel obj)
        {
            // get related components
            DS_Player player = await GetPlayer(obj.PlayerId);
            DS_Company company = _context.DS_Company.FirstOrDefault(c => c.Id == obj.CompanyId);

            #region Check if transaction is possible
            if (player == null || company == null)
            {
                return false;
            }
            else if (company.totalStocks < obj.TotalStocks)
            {
                return false;
            }

            double stockCost = company.stockValues * obj.TotalStocks;

            if (player.Balance < stockCost)
            {
                return false;
            }
            #endregion

            #region Calculate transaction score

            long transactionScore = 0;

            double y = company.stockValues;
            int b = -2499;
            int m = 12500;

            double multiplier = (y - b) / m;

            transactionScore = (long)(stockCost * multiplier);

            #endregion

            #region Calculate New Stock Value for the Company

            double newStockValue = 0;

            int stockQuantityForCalculation = company.totalStocks + obj.TotalStocks;

            double stockValueMultiplier = ((double)stockQuantityForCalculation / company.totalStocks);

            newStockValue = company.stockValues * stockValueMultiplier;

            #endregion

            #region Deduct Number of Stocks with Stock Value

            company.stockValues = (int)newStockValue;
            company.totalStocks -= obj.TotalStocks;

            #endregion

            #region Add Stocks to user.

            DS_PlayerInventory existingInventory = _context.DS_PlayerInventory.Where(x => x.PlayerId == player.Id).Where(x => x.CompanyId == company.Id).AsEnumerable().FirstOrDefault();
            bool newInventory = false;

            if (existingInventory == null)
            {
                // i.e. player inventory does not exist for that company
                existingInventory = new DS_PlayerInventory();
                existingInventory.PlayerId = player.Id;
                existingInventory.CompanyId = company.Id;
                existingInventory.OwnedStocks = obj.TotalStocks;
                newInventory = true;
            }
            else
            {
                // i.e. player inventory exists for that player
                existingInventory.OwnedStocks += obj.TotalStocks;
            }

            #endregion

            #region Update User Score

            player.Score -= transactionScore;
            player.Balance -= stockCost;

            #endregion

            #region Add to transaction logs.

            TransactionLogs log = new TransactionLogs();
            log.Transaction = $"[Buy Stock] [Player]:{player.Id}||[Company]{company.Id}||[Score]{-transactionScore}||[Balance]{player.Balance}";

            #endregion

            #region Commit
            try
            {
                // Saving Company
                _context.DS_Company.Update(company);

                // Saving UserInventory
                if (newInventory)
                {
                    _context.DS_PlayerInventory.Add(existingInventory);
                }
                else
                {
                    _context.DS_PlayerInventory.Update(existingInventory);
                }

                // Saving User
                _context.DS_Player.Update(player);

                // Saving Transaction
                _context.TransactionLogs.Add(log);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }

            // Commit
            _context.SaveChanges();

            #endregion

            return true;
        }

        public Task<IEnumerable<DS_PlayerInventory>> GetPlayerInventory(int id)
        {
            var inventory = _context.DS_PlayerInventory.Where(x => x.PlayerId == id).AsEnumerable();
            return Task.FromResult(inventory);
        }

        public Task ResetGame()
        {
            RemoveAllInventory();
            RemoveAllNewsEvents();
            RemoveAllCompanies();
            RemoveAllCompanyCategories();
            RemoveAllNewCompanyNames();
            RemoveAllNewsTypes();
            RemoveAllUsers();
            RemoveAllTransactionLogs();

            return Task.CompletedTask;
        }

        public void RemoveAllInventory()
        {
            var dS_PlayerInventory = _context.DS_PlayerInventory.AsEnumerable();
            foreach (var i in dS_PlayerInventory)
            {
                _context.DS_PlayerInventory.Remove(i);
            }
            _context.SaveChanges();
        }

        public void RemoveAllNewsEvents()
        {
            var list = _context.DS_NewsEvent.AsEnumerable();
            foreach (var i in list)
            {
                _context.DS_NewsEvent.Remove(i);
            }
            _context.SaveChanges();
        }

        public void RemoveAllCompanies()
        {
            var list = _context.DS_Company.AsEnumerable();
            foreach (var i in list)
            {
                _context.DS_Company.Remove(i);
            }
            _context.SaveChanges();
        }

        public void RemoveAllCompanyCategories()
        {
            var list = _context.DS_CompanyCategory.AsEnumerable();
            foreach (var i in list)
            {
                _context.DS_CompanyCategory.Remove(i);
            }
            _context.SaveChanges();
        }

        public void RemoveAllNewCompanyNames()
        {
            var list = _context.DS_NewCompanyNames.AsEnumerable();
            foreach (var i in list)
            {
                _context.DS_NewCompanyNames.Remove(i);
            }
            _context.SaveChanges();
        }

        public void RemoveAllNewsTypes()
        {
            var list = _context.DS_EventTypes.AsEnumerable();
            foreach (var i in list)
            {
                _context.DS_EventTypes.Remove(i);
            }
            _context.SaveChanges();
        }

        public void RemoveAllUsers()
        {
            var list = _context.DS_Player.AsEnumerable();
            foreach (var i in list)
            {
                _context.DS_Player.Remove(i);
            }
            _context.SaveChanges();
        }

        public void RemoveAllTransactionLogs()
        {
            var list = _context.TransactionLogs.AsEnumerable();
            foreach (var i in list)
            {
                _context.TransactionLogs.Remove(i);
            }
            _context.SaveChanges();
        }
    }
}
