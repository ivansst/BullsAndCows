using BullsAndCows.Models;
using BullsAndCows.Repository.Interfaces;
using BullsAndCows.Services.Interfaces;
using System;

namespace BullsAndCows.Services
{
    public class GameService : IGameService
    {
        //private static int? computerSecret;
        private readonly IUserTriesRepository _userTriesRepository;
        private readonly IUserRepository _userRepository;

        public GameService(IUserTriesRepository userTriesRepository,
                           IUserRepository userRepository)
        {
            _userTriesRepository = userTriesRepository;
            _userRepository = userRepository;
        }

        public GameModel PlayGame(GameModel model, string playerUsername)
        {
            var userId = _userRepository.GetIdByEmail(playerUsername);
            var resultModel = new GameModel { };
            model.Attempts += 1;

            if (model.ComputerSecret == default)
            {
                model.ComputerSecret = GenerateComputerSecret();
            }

            if (model.PlayerGuess != model.ComputerSecret)
            {
                var result = CheckAttempt(model.ComputerSecret.ToString(), model.PlayerGuess.ToString());

                resultModel.CorrectGuesses = result;
                resultModel.PlayerGuess = model.PlayerGuess;
                resultModel.Attempts = model.Attempts;
                resultModel.ComputerSecret = model.ComputerSecret;

                return resultModel;
            }

            _userTriesRepository.Insert(userId, model.Attempts);

            resultModel.CorrectGuesses = $"Congratulations! You've beaten the game in {model.Attempts} tries!";
            resultModel.PlayerGuess = model.PlayerGuess;
            resultModel.Attempts = model.Attempts;

            return resultModel;
        }

        public int GenerateComputerSecret()
        {
            var rand = new Random();
            var randomNum = rand.Next(1000, 9999);

            return randomNum;
        }

        private string CheckAttempt(string computerSecret, string playerGuess)
        {
            int[] frequency = new int[10];
            foreach (char c in computerSecret)
            {
                frequency[c - '0']++;
            }

            var bulls = 0;
            var cows = 0;

            for (int i = 0; i < computerSecret.Length; i++)
            {
                if (computerSecret[i] == playerGuess[i])
                {
                    bulls++;
                }
                if (frequency[playerGuess[i] - '0'] > 0)
                {
                    cows++;
                    frequency[playerGuess[i] - '0']--;
                }
            }

            cows -= bulls;

            return $"You've guessed {bulls} Bulls and {cows} Cows";
        }
    }
}
