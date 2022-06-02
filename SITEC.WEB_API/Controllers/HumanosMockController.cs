using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SITEC.WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITEC.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanosMockController : ControllerBase
    {
        #region Properties
        private Humano[] humanos;
        #endregion

        #region Constructor
        public HumanosMockController()
        {
            humanos = new Humano[2];

            humanos[0] = new Humano { Id = 1, Nombre = "Raúl", Sexo = true, Altura = 1.74, Peso = 90.5, Edad = 34 };
            humanos[1] = new Humano { Id = 2, Nombre = "Marila", Sexo = false, Altura = 1.65, Peso = 65, Edad = 30 };
        }
        #endregion

        #region Web API´s
        [HttpGet]
        public ActionResult<IEnumerable<Humano>> Get()
        {
            return humanos;
        } 
        #endregion
    }
}
