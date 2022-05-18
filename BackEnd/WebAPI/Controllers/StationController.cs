using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        public StationController()
        {

        }

        [HttpPost]
        public async Task<ActionResult> CreateStation(StationViewModel stationViewModel)
        {
            var station = _
            return Ok();
        }
    }
}
