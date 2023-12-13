using System.ComponentModel.DataAnnotations;

namespace FinalProjectGym_management.ViewModels
{
    public class MembersVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string IdCardNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
