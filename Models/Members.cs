using System.ComponentModel.DataAnnotations;

namespace FinalProjectGym_management.Models
{
    public class Members
    {
        [Required]
        public int Id { get; set; } 
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public int IdCardNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Registration_Date { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
