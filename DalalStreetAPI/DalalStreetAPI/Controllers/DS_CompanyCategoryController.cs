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
    public class DS_CompanyCategoryController : Controller
    {
        private readonly IDS_CompanyCategoryService _dsService;

        public DS_CompanyCategoryController(IDS_CompanyCategoryService dsService)
        {
            _dsService = dsService;
        }

        //GET: api/DS_CompanyCategory
        [HttpGet()]
        [Route("allrecords")]
        [ProducesResponseType(typeof(IEnumerable<DS_CompanyCategory>), 200)]
        public async Task<IEnumerable<DS_CompanyCategory>> GetCategoriesAsync()
        {
            IEnumerable<DS_CompanyCategory> records = await _dsService.GetAllAsync();

            return records;
        }

        //GET api/DS_CompanyCategory/id
        [HttpGet("{id}", Name = nameof(GetCategoryByIdAsync))]
        [ProducesResponseType(typeof(DS_CompanyCategory), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            DS_CompanyCategory record = await _dsService.FindAsync(id);
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
        [ProducesResponseType(typeof(DS_CompanyCategory), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostCategoryAsync([FromBody]DS_CompanyCategory record)
        {
            if (record == null)
            {
                return BadRequest();
            }
            await _dsService.AddAsync(record);
            return CreatedAtRoute(nameof(GetCategoryByIdAsync), new { id = record.Id }, record);
        }

        //PUT api/DS_CompanyCategory/id
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutCategoryAsync(int id, [FromBody]DS_CompanyCategory record)
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

        //DELETE api/DS_CompanyCategory/id
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id) => await _dsService.RemoveAsync(id);
    }
}