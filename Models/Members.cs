using System.ComponentModel.DataAnnotations;

namespace FinalProjectGym_management.Models
{
    public class Members
    {
        [Required]
        public int Id { get; set; } //check
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public int IdCardNumber { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime Registration_Date { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
