using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoEU.Models.DTO
{
    public class RegistrationModel
    {
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
            + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
            ErrorMessage = "You have entered an invalid email address")]
        [Key]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string PassConfirm { get; set; }
        public string ? Role { get; set; }
    }
}
