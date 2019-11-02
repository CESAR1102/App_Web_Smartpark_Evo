using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;
namespace Smartpark.Api.Controllers
{
    [Route("api/ingresos")]
    [ApiController]
    public class IngresoController:ControllerBase
    {
        private IIngresoService ingresoService;
        public IngresoController(IIngresoService ingresoService)
        {
            this.ingresoService = ingresoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                ingresoService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ingreso ingreso)
        {
            return Ok(
                ingresoService.Save(ingreso)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Ingreso ingreso)
        {
            return Ok(
                ingresoService.Update(ingreso)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                ingresoService.Delete(id)
            );
        }
    }
}