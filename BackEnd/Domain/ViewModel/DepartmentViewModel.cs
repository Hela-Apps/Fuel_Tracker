using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
   public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public bool Active { get; set; }
    }
}
