using Microsoft.AspNetCore.Mvc;

namespace BusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusSeat : ControllerBase
    {
        [HttpGet("template/{idBusSchedule}")]
        public async Task Get(int idBusSchedule)
        {

        }
    }
}
