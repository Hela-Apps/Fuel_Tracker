using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Models
{
    public class StationFuelType
    {
        [Key]
        public int Id { get; set; }
        public int StationId { get; set; }
        public bool IsActive { get; set; }
        public int FuelTypeId { get; set; }
        public bool Availability { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }
}
