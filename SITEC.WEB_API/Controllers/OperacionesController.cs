using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITEC.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        #region Web API´s
        [HttpGet("{numero1}/{numero2}/{numero3}")]
        public ActionResult<double> Suma(double numero1, double numero2, double numero3)
        {
            double resultado = numero1 + numero2 + numero3;

            return resultado;
        }


        [HttpPost()]
        public ActionResult<double> Resta()
        {
            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

            var a = Convert.ToDouble(dict["numero1"]);
            var b = Convert.ToDouble(dict["numero2"]);
            var c = Convert.ToDouble(dict["numero3"]);

            return a - b - c;

        } 
        #endregion
    }
}
