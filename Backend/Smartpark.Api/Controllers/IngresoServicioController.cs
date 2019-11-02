using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;

namespace Smartpark.Api.Controllers
{
    [Route("api/ingresoservicios")]
    [ApiController]
    public class IngresoServicioController:ControllerBase
    {
        private IIngresoServicioService ingresoServicioService;
        public IngresoServicioController(IIngresoServicioService ingresoServicioService)
        {
            this.ingresoServicioService = ingresoServicioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                ingresoServicioService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] IngresoServicio ingresoServicio)
        {
            return Ok(
                ingresoServicioService.Save(ingresoServicio)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] IngresoServicio ingresoServicio)
        {
            return Ok(
                ingresoServicioService.Update(ingresoServicio)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                ingresoServicioService.Delete(id)
            );
        }
    }
}