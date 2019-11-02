
using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;
namespace Smartpark.Api.Controllers
{
    [Route("api/parkings")]
    [ApiController]
    public class ParkingController:ControllerBase
    {
        private IParkingService parkingService;
        public ParkingController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                parkingService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Parking parking)
        {
            return Ok(
                parkingService.Save(parking)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Parking parking)
        {
            return Ok(
                parkingService.Update(parking)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                parkingService.Delete(id)
            );
        }
    }
}