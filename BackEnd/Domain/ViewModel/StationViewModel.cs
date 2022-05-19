using AutoMapper;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class StationViewModel:Station
    {
        
    }

    public class StationProfile : Profile
    {
        public StationProfile()
        {
            CreateMap<Station, StationViewModel>();
        }
       
    }
}
