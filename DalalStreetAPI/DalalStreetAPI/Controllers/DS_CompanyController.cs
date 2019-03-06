using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DalalStreetAPI.Models;
using DalalStreetAPI.Services;

namespace DalalStreetAPI.Controllers
{
    [Route("api/[controller]")]
    public class DS_CompanyController : Controller
    {
        private readonly IDS_CompanyService _dsService;

        public DS_CompanyController(IDS_CompanyService _dsService)
        {
            this._dsService = _dsService;
        }

        //GET: api/DS_Company
        [HttpGet()]
        [Route("allrecords")]
        [ProducesResponseType(typeof(IEnumerable<DS_Company>), 200)]
        public async Task<IEnumerable<DS_Company>> GetRecordsAsync()
        {
            IEnumerable<DS_Company> records = await _dsService.GetAllAsync();

            return records;
        }

        //GET api/DS_Company/id
        [HttpGet("{id}", Name = nameof(GetRecordByIdAsync))]
        [ProducesResponseType(typeof(DS_Company), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetRecordByIdAsync(int id)
        {
            DS_Company record = await _dsService.FindAsync(id);
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
        [ProducesResponseType(typeof(DS_Company), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostRecordAsync([FromBody]DS_Company record)
        {
            if (record == null)
            {
                return BadRequest();
            }
            await _dsService.AddAsync(record);
            return CreatedAtRoute(nameof(GetRecordByIdAsync), new { id = record.Id }, record);
        }

        //PUT api/DS_Company/id
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutrecordAsync(int id, [FromBody]DS_Company record)
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

        //DELETE api/DS_Company/id
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id) => await _dsService.RemoveAsync(id);
    }
}