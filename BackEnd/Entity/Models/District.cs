using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        public int ProvienceId { get; set; }
        public string  Name { get; set; }
        public bool IsActive { get; set; }
    }
}
