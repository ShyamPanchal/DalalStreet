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
    public class DS_NewCompanyNamesController : Controller
    {
        private readonly IDS_NewCompanyNamesService _dsService;

        public DS_NewCompanyNamesController(IDS_NewCompanyNamesService dsService)
        {
            _dsService = dsService;
        }

        //GET: api/DS_NewCompanyNames
        [HttpGet()]
        [Route("allrecords")]
        [ProducesResponseType(typeof(IEnumerable<DS_NewCompanyNames>), 200)]
        public async Task<IEnumerable<DS_NewCompanyNames>> GetNewCompanyNamesAsync()
        {
            IEnumerable<DS_NewCompanyNames> records = await _dsService.GetAllAsync();

            return records;
        }

        //GET api/DS_NewCompanyNames/id
        [HttpGet("{id}", Name = nameof(GetNewCompanyNamesByIdAsync))]
        [ProducesResponseType(typeof(DS_NewCompanyNames), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetNewCompanyNamesByIdAsync(int id)
        {
            DS_NewCompanyNames record = await _dsService.FindAsync(id);
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
        [ProducesResponseType(typeof(DS_NewCompanyNames), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostNewCompanyNamesAsync([FromBody]DS_NewCompanyNames record)
        {
            if (record == null)
            {
                return BadRequest();
            }
            await _dsService.AddAsync(record);
            return CreatedAtRoute(nameof(GetNewCompanyNamesByIdAsync), new { id = record.Id }, record);
        }

        //PUT api/DS_NewCompanyNames/id
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutNewCompanyNamesAsync(int id, [FromBody]DS_NewCompanyNames record)
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

        //DELETE api/DS_NewCompanyNames/id
        [HttpDelete("{id}")]
        public async Task DeleteNewCompanyNamesAsync(int id) => await _dsService.RemoveAsync(id);
    }
}