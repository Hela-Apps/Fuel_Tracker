using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassifiedAds.Tools.ExtractExcel.ViewModels
{
    public class CityViewModel
    {
        //[JsonProperty("Id")]
        //public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DistrictId")]
        public int DistrictId { get; set; }

        [JsonProperty("PostCode")]
        public string PostCode { get; set; }

        [JsonProperty("Latitude")]
        public float Latitude { get; set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
    }
}
