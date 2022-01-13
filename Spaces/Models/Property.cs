using System;
using System.ComponentModel.DataAnnotations;

namespace Spaces.Models
{
    public class Property
    {
        public int Id { get; set; }
        [Required]
        public int UserProfileId { get; set; }
        public int TenantId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        public decimal MonthlyMortageAmount { get; set; }
        public decimal SecurityDeposit { get; set; }
        public DateTime DateAquired { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
        public string Image { get; set; }
        public decimal MonthlyTargetProfit { get; set; }
        public int MonthlyTargetBooking { get; set; }
        public decimal AverageMonthlyProfit { get; set; }
        public decimal AverageMonthlyMaintenance { get; set; }
        public decimal TweleveMonthProfirLoss { get; set; }
        public decimal ThirtyDayProfitLoss { get; set; }
        public decimal AllTimeProfitLoss { get; set; }
        public decimal AllTimeMaintenance { get; set; }
        public decimal AllTimeMortageCost { get; set; }
        public decimal TweleveMonthProfit { get; set; }
        public decimal ThirtyDayProfit { get; set; }
        public decimal AllTimeProfit { get; set; }
        public string Notes { get; set; }
        public string CheckOutTime { get; set; }
        public string CheckInTime { get; set; }
    }
}
