using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DalalStreetAPI.Models;
using DalalStreetAPI.Models.ViewModels;
using DalalStreetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DalalStreetAPI.Controllers
{
    [Route("api/[controller]")]
    public class DS_PlayerController : Controller
    {
        private readonly IDS_PlayerService _service;

        public DS_PlayerController(IDS_PlayerService _service)
        {
            this._service = _service;
        }

        //GET: api/DS_Player
        [HttpGet()]
        [Route("allPlayers")]
        [ProducesResponseType(typeof(IEnumerable<DS_Player>), 200)]
        public async Task<IEnumerable<DS_Player>> GetPlayersAsync()
        {
            IEnumerable<DS_Player> records = await _service.GetAllPlayers();

            return records;
        }

        //GET api/DS_Player/id
        [HttpGet("getPlayer/{id}", Name = nameof(GetPlayerByIdAsync))]
        [ProducesResponseType(typeof(DS_Player), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPlayerByIdAsync(int id)
        {
            DS_Player player = await _service.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(player);
            }
        }

        //POST api/DS_Player
        [HttpPost("addPlayer")]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPlayerAsync([FromBody]string playerName)
        {
            if (playerName == null)
            {
                return BadRequest();
            }
            else if(playerName == "")
            {
                return BadRequest();
            }

            DS_Player player = new DS_Player();

            player.Name = playerName;
            player.Balance = AppData.InitialStartMoney;
            player.Score = 0;

            await _service.AddPlayer(player);

            return CreatedAtRoute(nameof(GetPlayerByIdAsync), new { id = player.Id }, player);
        }

        //POST api/DS_Player/buy
        [HttpPost("buy", Name = nameof(BuyStocksAsync))]
        [ProducesResponseType(typeof(TransactionModel), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> BuyStocksAsync([FromBody]TransactionModel obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            bool result = await _service.BuyStocks(obj);
            return new ObjectResult(result);
        }

        //POST api/DS_Player/sell
        [HttpPost("sell", Name = nameof(SellStocksAsync))]
        [ProducesResponseType(typeof(TransactionModel), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SellStocksAsync([FromBody]TransactionModel obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            bool result = await _service.BuyStocks(obj);
            return new ObjectResult(result);
        }

        //GET: api/DS_Player
        [HttpGet()]
        [Route("playerInventory/{id}")]
        [ProducesResponseType(typeof(IEnumerable<DS_PlayerInventory>), 200)]
        public async Task<IEnumerable<DS_PlayerInventory>> GetPlayerInventoryAsync(int id)
        {
            IEnumerable<DS_PlayerInventory> records = await _service.GetPlayerInventory(id);

            return records;
        }
    }
}