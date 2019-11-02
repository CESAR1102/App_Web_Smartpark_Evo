using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;
namespace Smartpark.Api.Controllers
{
    [Route("api/comprobantes")]
    [ApiController]
    public class ComprobanteController:ControllerBase
    {
        private IComprobanteService comprobanteService;
        public ComprobanteController(IComprobanteService comprobanteService)
        {
            this.comprobanteService = comprobanteService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                comprobanteService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Comprobante comprobante)
        {
            return Ok(
                comprobanteService.Save(comprobante)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Comprobante comprobante)
        {
            return Ok(
                comprobanteService.Update(comprobante)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                comprobanteService.Delete(id)
            );
        }
    }
}