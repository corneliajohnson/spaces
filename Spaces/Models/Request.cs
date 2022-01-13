﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spaces.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public int PropertyId { get; set; }
        [Required]
        public string Synopsis { get; set; }
        [Required]
        public string Contractor { get; set; }
        public bool IsComplete { get; set; }
        public string Note { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateAdded { get; set; }
    }
}