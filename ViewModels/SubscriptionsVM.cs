using System.ComponentModel.DataAnnotations;

namespace FinalProjectGym_management.ViewModels
{
    public class SubscriptionsVM
    {
        [Required]
        public int Code { get; set; } // check 
        [Required]
        public string Description { get; set; }
        [Required]
        public int NumberOfMonths { get; set; }
        [Required]
        public int WeekFrequency { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
