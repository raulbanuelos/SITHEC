using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SITEC.WEB_API.Data;
using SITEC.WEB_API.Models;
using SITEC.WEB_API.Repository;
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
        private readonly IHumanoRepository _humanoRepository;
        #endregion

        #region Constructor
        public HumanosController(IHumanoRepository humanoRepository)
        {
            _humanoRepository = humanoRepository;
        }
        #endregion

        #region Web API´s
        [HttpGet]
        public IActionResult Get()
        {
            var humanos = _humanoRepository.GetHumanos();
            return new OkObjectResult(humanos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var humano = _humanoRepository.GetHumanoByID(id);

            if (humano == null)
            {
                return NotFound();
            }

            return new OkObjectResult(humano);
        }

        [HttpPost]
        public IActionResult Insert(Humano humano)
        {
            _humanoRepository.InsertHumano(humano);

            return CreatedAtAction(nameof(GetById), new { id = humano.Id }, humano);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Humano humano)
        {
            if (id != humano.Id)
            {
                return BadRequest();
            }

            _humanoRepository.UpdateHumano(humano);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _humanoRepository.DeleteHumano(id);

            return new OkResult();
        } 
        #endregion

    }
}
