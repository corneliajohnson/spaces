using System;
using System.ComponentModel.DataAnnotations;

namespace Spaces.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        public int PropertyId { get; set; }
        [Required]
        public int TenantId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal PaymentAmount {get; set;}
        [Required]
        public bool IsSecurityDeposit { get; set; }
    }
}
