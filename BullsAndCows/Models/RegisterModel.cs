using System.ComponentModel.DataAnnotations;

namespace BullsAndCows.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Username is required or is already taken!")]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords must match!")]
        public string ConfirmPassword { get; set; }
    }
}
