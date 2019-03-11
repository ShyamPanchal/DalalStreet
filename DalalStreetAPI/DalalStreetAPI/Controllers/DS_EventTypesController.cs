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

    public class DS_EventTypesController : Controller
    {
        private readonly IDS_EventTypesService _dsService;

        public DS_EventTypesController(IDS_EventTypesService dsService)
        {
            _dsService = dsService;
        }

        //GET: api/DS_EventTypes
        [HttpGet()]
        [Route("allrecords")]
        [ProducesResponseType(typeof(IEnumerable<DS_EventTypes>), 200)]
        public async Task<IEnumerable<DS_EventTypes>> GetEventTypesAsync()
        {
            IEnumerable<DS_EventTypes> records = await _dsService.GetAllAsync();

            return records;
        }

        //GET api/DS_EventTypes/id
        [HttpGet("{id}", Name = nameof(GetEventTypesByIdAsync))]
        [ProducesResponseType(typeof(DS_EventTypes), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEventTypesByIdAsync(int id)
        {
            DS_EventTypes record = await _dsService.FindAsync(id);
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
        [ProducesResponseType(typeof(DS_EventTypes), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostEventTypesAsync([FromBody]DS_EventTypes record)
        {
            if (record == null)
            {
                return BadRequest();
            }
            await _dsService.AddAsync(record);
            return CreatedAtRoute(nameof(GetEventTypesByIdAsync), new { id = record.Id }, record);
        }

        //PUT api/DS_EventTypes/id
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutEventTypesAsync(int id, [FromBody]DS_EventTypes record)
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

        //DELETE api/DS_EventTypes/id
        [HttpDelete("{id}")]
        public async Task DeleteEventTypesAsync(int id) => await _dsService.RemoveAsync(id);
    }
}