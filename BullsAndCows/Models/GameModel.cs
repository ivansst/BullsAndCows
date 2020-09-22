using System.ComponentModel.DataAnnotations;

namespace BullsAndCows.Models
{
    public class GameModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Range(1000, 9999, ErrorMessage = "The number must be between 1000 and 9999!")]
        public int PlayerGuess { get; set; }

        public int Attempts { get; set; }

        public string CorrectGuesses { get; set; }

        public int ComputerSecret { get; set; }
    }
}
