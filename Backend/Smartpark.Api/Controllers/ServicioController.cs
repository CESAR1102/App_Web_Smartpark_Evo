using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;
namespace Smartpark.Api.Controllers
{
    [Route("api/servicios")]
    [ApiController]
    public class ServicioController:ControllerBase
    {
        private IServicioService servicioService;
        public ServicioController(IServicioService servicioService)
        {
            this.servicioService = servicioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                servicioService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Servicio servicio)
        {
            return Ok(
                servicioService.Save(servicio)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Servicio servicio)
        {
            return Ok(
                servicioService.Update(servicio)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                servicioService.Delete(id)
            );
        }
    }
}