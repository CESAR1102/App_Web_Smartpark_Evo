using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;

namespace Smartpark.Api.Controllers
{
    [Route("api/espacios")]
    [ApiController]
    public class EspacioController:ControllerBase
    {
        private IEspacioService espacioService;
        public EspacioController(IEspacioService espacioService)
        {
            this.espacioService = espacioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                espacioService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Espacio espacio)
        {
            return Ok(
                espacioService.Save(espacio)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Espacio espacio)
        {
            return Ok(
                espacioService.Update(espacio)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                espacioService.Delete(id)
            );
        }
    }
}