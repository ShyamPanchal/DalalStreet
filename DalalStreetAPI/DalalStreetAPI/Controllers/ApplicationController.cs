using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DalalStreetAPI.Models;

namespace DalalStreetAPI.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        public ApplicationController()
        { }

        [HttpGet()]
        [Route("getgamestart")]
        [ProducesResponseType(typeof(bool), 200)]
        public bool GetApplicationStartStatus()
        {
            return AppData.isGameStart;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        public bool PostApplicationStartStatus([FromBody]bool gameStatus)
        {
            AppData.isGameStart = gameStatus;
            return gameStatus;
        }
    }
}