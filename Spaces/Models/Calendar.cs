using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spaces.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        [Required]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        [Required]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public decimal PaymentAmount { get; set; }
        [Required]
        public bool IsPaidInFull { get; set; }
        [Required]
        public bool IsSecuirtyDepositPaid { get; set; }
        [Required]
        public bool IsSecuirtyDepositReturned { get; set; }
        public DateTime Date { get; set; }

        internal List<Calendar> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
