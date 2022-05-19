using AutoMapper;
using Domain.StationDomain;
using Domain.ViewModel;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        private IMapper _mapper;
        //protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        public StationController(IStationService stationService, IMapper mapper)
        {
            _stationService = stationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateStation([FromBody] StationViewModel stationViewModel)
        {
            var station = _mapper.Map<Station>(stationViewModel);
            return Ok(await _stationService.Create(station));
        }

        [HttpGet]
        public async Task<ActionResult> GetStation(int id)
        {
            return Ok(await _stationService.Get(id));
        }


    }

}
