using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SITEC.WEB_API.Data;
using SITEC.WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITEC.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanosController : ControllerBase
    {
        #region Properties
        private readonly HumanoContext _context; 
        #endregion

        #region Constructor
        public HumanosController(HumanoContext context)
        {
            _context = context;
        }
        #endregion

        #region Web API´s
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Humano>>> Get()
        {
            return await _context.Humanos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Humano>> GetById(int id)
        {
            var humano = await _context.Humanos.FindAsync(id);

            if (humano == null)
            {
                return NotFound();
            }

            return humano;
        }

        [HttpPost]
        public async Task<ActionResult<Humano>> Insert(Humano humano)
        {
            _context.Humanos.Add(humano);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = humano.Id }, humano);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Humano humano)
        {
            if (id != humano.Id)
            {
                return BadRequest();
            }

            _context.Entry(humano).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var humano = await _context.Humanos.FindAsync(id);

            if (humano == null)
            {
                NotFound();
            }

            _context.Humanos.Remove(humano);
            await _context.SaveChangesAsync();

            return Ok();
        } 
        #endregion

    }
}
