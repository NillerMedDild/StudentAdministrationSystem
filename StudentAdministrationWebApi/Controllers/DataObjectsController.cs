using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAdministrationWebApi.DAL.Data;
using StudentAdministrationWebApi.DAL.Models;

namespace StudentAdministrationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataObjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DataObjectsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<DataObject> GetDataObjects()
        {
            return _context.DataObjects;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataObject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dataObject = await _context.DataObjects.FindAsync(id);

            if (dataObject == null)
            {
                return NotFound();
            }

            return Ok(dataObject);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataObject([FromRoute] int id, [FromBody] DataObject dataObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dataObject.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataObjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DataObjects
        [HttpPost]
        public async Task<IActionResult> PostDataObject([FromBody] DataObject dataObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DataObjects.Add(dataObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataObject", new { id = dataObject.Id }, dataObject);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataObject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dataObject = await _context.DataObjects.FindAsync(id);
            if (dataObject == null)
            {
                return NotFound();
            }

            if (dataObject.Historic)
            {
                return Ok();
            }

            dataObject.Historic = true;

            _context.Entry(dataObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataObjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(dataObject);
        }

        private bool DataObjectExists(int id)
        {
            return _context.DataObjects.Any(e => e.Id == id);
        }
    }
}