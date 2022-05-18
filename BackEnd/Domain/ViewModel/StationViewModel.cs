using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class StationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Company { get; set; }
        public int CityId { get; set; }
    }
}
