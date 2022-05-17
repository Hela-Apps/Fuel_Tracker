using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
