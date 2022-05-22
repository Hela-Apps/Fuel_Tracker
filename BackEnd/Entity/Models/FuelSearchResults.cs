using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
   public  class FuelSearchResults
    {
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string StationName { get; set; }
        public bool AvailabilityStatus { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}
