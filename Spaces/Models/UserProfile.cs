using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spaces.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string FirebaseId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Property> Properties { get; set; }
    }
}
