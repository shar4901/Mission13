﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerId { get; set; }
        public string BowlerLastName { get; set; }
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }
        public string BowlerState { get; set; }

        public string BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }

        public int? TeamId{ get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }

    }
}
