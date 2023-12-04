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
        public int IdCardNumber { get; set; }
        [Required]
        public string Email { get; set; }
        
    }
}
