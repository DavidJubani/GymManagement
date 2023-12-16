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
        [Display(Name = "Number of Months")]
        public int NumberOfMonths { get; set; }
        [Required]
        [Display(Name = "Week Frequency")]
        public int WeekFrequency { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
    }
}
