using System.ComponentModel.DataAnnotations;

namespace FinalProjectGym_management.Models
{
    public class Subscriptions
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Code { get; set; } // check 
        [Required]
        public string Description { get; set; }
        [Required]
        public int NumberOfMonths { get; set; }
        [Required]
        public int WeekFrequency { get; set; }
        [Required]
        public int TotalNumberOfSessions { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

    }

    
}
