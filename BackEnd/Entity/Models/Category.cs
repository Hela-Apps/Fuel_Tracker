﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
