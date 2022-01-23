using System.ComponentModel.DataAnnotations;

namespace WhooberCore.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is not stated")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}