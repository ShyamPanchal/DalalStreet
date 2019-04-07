using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DalalStreetAPI.Models;
using DalalStreetAPI.Services;

namespace DalalStreetAPI.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        private readonly IDS_PlayerService _service;

        public ApplicationController(IDS_PlayerService _service)
        {
            this._service = _service;
        }

        [HttpGet()]
        [Route("getgamestart")]
        [ProducesResponseType(typeof(bool), 200)]
        public bool GetApplicationStartStatus()
        {
            return AppData.isGameStart;
        }

        [HttpGet("Start")]
        [ProducesResponseType(typeof(bool), 200)]
        public bool StartGame()
        {
            AppData.isGameStart = true;
            return AppData.isGameStart;
        }

        [HttpGet("Stop")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<object> StopGame()
        {
            try
            {
                await _service.SellAllPlayerStocks();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            AppData.isGameStart = false;
            return new ObjectResult(AppData.isGameStart);
        }

        [HttpGet("Reset")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<object> ResetGame()
        {
            try
            {
                await _service.ResetGame();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            AppData.isGameStart = false;
            return new ObjectResult("Successful");
        }
    }
}