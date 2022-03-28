﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int CaptainId { get; set; }
        //public Bowler Captain { get; set; }
    }
}
