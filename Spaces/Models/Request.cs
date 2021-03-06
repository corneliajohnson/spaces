using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spaces.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        [Required]
        public string Synopsis { get; set; }
        [Required]
        public string Contractor { get; set; }
        public bool IsComplete { get; set; }
        public string Note { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateAdded { get; set; }

        internal List<Request> ToList()
        {
            throw new NotImplementedException();
        }
        public bool isActive { get; set; }
    }
}