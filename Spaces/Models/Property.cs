using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spaces.Models
{
    public class Property
    {
        public int Id { get; set; }
        [Required]
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }
        public decimal MonthlyMortageAmount { get; set; }
        public decimal SecurityDeposit { get; set; }
        public DateTime DateAcquired { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
        public string Image { get; set; }
        public decimal MonthlyTargetProfit { get; set; }
        public int MonthlyTargetBookings { get; set; }
        public decimal AverageMonthlyProfit { get; set; }
        public decimal AverageMonthlyMaintenance { get; set; }
        public decimal TwelveMonthProfitLoss { get; set; }
        public decimal ThirtyDayProfitLoss { get; set; }
        public decimal AllTimeProfitLoss { get; set; }
        public decimal AllTimeMaintenance { get; set; }

        internal List<Property> ToList()
        {
            throw new NotImplementedException();
        }

        public decimal AllTimeMortageCost { get; set; }
        public decimal TwelveMonthProfit { get; set; }
        public decimal ThirtyDayProfit { get; set; }
        public decimal AllTimeProfit { get; set; }
        public string Notes { get; set; }
        public string CheckOutTime { get; set; }
        public string CheckInTime { get; set; }

        //public List<Payment> Payments { get; set; }
        //public List<Request> Requests { get; set; }
        //public List<Calendar> Calendars { get; set; }
        public bool isActive { get; set; }
    }
}
