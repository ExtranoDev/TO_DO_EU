using System.ComponentModel.DataAnnotations;

namespace ToDoEU.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Incorrect Password, Try Again")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
