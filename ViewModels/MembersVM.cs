using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace FinalProjectGym_management.ViewModels
{
    public class MembersVM
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthday { get; set; }
        [Display(Name = "ID Card Number")]
        [Required]
        public string IdCardNumber { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
    }
}
