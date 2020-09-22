using System.ComponentModel.DataAnnotations;

namespace BullsAndCows.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="This field is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }
    }
}
