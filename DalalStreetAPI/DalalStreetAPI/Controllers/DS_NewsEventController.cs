using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DalalStreetAPI.Services;
using DalalStreetAPI.Models;

namespace DalalStreetAPI.Controllers
{
    [Route("api/[controller]")]
    public class DS_NewsEventController : Controller
    {
        private readonly IDS_NewsEventService _dsService;

        public DS_NewsEventController(IDS_NewsEventService dsService)
        {
            _dsService = dsService;
        }

        //GET: api/DS_NewsEvent
        [HttpGet]
        [Route("allrecords/{count}")]
        [ProducesResponseType(typeof(IEnumerable<DS_NewsEvent>), 200)]
        public async Task<IEnumerable<DS_NewsEvent>> GetNewsEventAsync(int count)
        {
            IEnumerable<DS_NewsEvent> records = await _dsService.GetAllAsync(count);

            return records;
        }

        //GET api/DS_NewsEvent/id
        [HttpGet("{id}", Name = nameof(GetNewsEventByIdAsync))]
        [ProducesResponseType(typeof(DS_NewsEvent), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetNewsEventByIdAsync(int id)
        {
            DS_NewsEvent record = await _dsService.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(record);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(DS_NewsEvent), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostNewsEventAsync([FromBody]DS_NewsEvent record)
        {
            if (record == null)
            {
                return BadRequest();
            }
            await _dsService.AddAsync(record);
            return CreatedAtRoute(nameof(GetNewsEventByIdAsync), new { id = record.Id }, record);
        }

        //PUT api/DS_NewsEvent/id
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutNewsEventAsync(int id, [FromBody]DS_NewsEvent record)
        {
            if (record == null || id != record.Id)
            {
                return BadRequest();
            }
            if (await _dsService.FindAsync(id) == null)
            {
                return NotFound();
            }
            await _dsService.UpdateAsync(record);
            return new NoContentResult();
        }

        //DELETE api/DS_NewsEvent/id
        [HttpDelete("{id}")]
        public async Task DeleteNewsEventAsync(int id) => await _dsService.RemoveAsync(id);
    }
}