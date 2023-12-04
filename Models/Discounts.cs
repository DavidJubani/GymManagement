using System.ComponentModel.DataAnnotations;

namespace FinalProjectGym_management.Models
{
    public class Discounts
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime DeactivationDate { get; set; }

    }
}
