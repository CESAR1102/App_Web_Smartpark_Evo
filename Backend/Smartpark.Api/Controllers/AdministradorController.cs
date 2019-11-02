using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;
namespace Smartpark.Api.Controllers
{
    [Route("api/administradores")]
    [ApiController]
    public class AdministradorController:ControllerBase
    {
        private IAdministradorService administradorService;
        public AdministradorController(IAdministradorService administradorService)
        {
            this.administradorService = administradorService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                administradorService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Administrador administrador)
        {
            return Ok(
                administradorService.Save(administrador)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Administrador administrador)
        {
            return Ok(
                administradorService.Update(administrador)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                administradorService.Delete(id)
            );
        }
    }
}