using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;
namespace Smartpark.Api.Controllers
{
    [Route("api/cajeros")]
    [ApiController]
    public class CajeroController:ControllerBase
    {
        private ICajeroService cajeroService;
        public CajeroController(ICajeroService cajeroService)
        {
            this.cajeroService = cajeroService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                cajeroService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Cajero cajero)
        {
            return Ok(
                cajeroService.Save(cajero)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Cajero cajero)
        {
            return Ok(
                cajeroService.Update(cajero)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                cajeroService.Delete(id)
            );
        }
    }
}