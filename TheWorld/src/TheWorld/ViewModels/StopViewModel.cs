﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.ViewModels
{
    public class StopViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 255)]
        public string Name { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Arrival { get; set; }
    }
}
