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
using Domain.StationDetailDomain;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        private readonly IStationDetailService _stationDetailService;
        private IMapper _mapper;
        public StationController(IStationService stationService, IStationDetailService stationDetailService, IMapper mapper)
        {
            _stationService = stationService;
            _stationDetailService = stationDetailService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateStation([FromBody] StationViewModel stationViewModel)
        {
            var station = _mapper.Map<Station>(stationViewModel);
            await _stationService.Create(station);
            await _stationDetailService.AddAutomatedStationDetails(station.Id);
            return Ok(station);
        }

        [HttpGet("GetStation")]
        public async Task<ActionResult> GetStation(int id)
        {
            return Ok(await _stationService.Get(id));
        }

        [HttpGet("CreateStationDetail")]
        public async Task<ActionResult> CreateStationDetail(int stationId)
        {
            return Ok(await _stationDetailService.GetStationDetailList(stationId));
        }

    }

}
