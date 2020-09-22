using BullsAndCows.Models;
using BullsAndCows.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BullsAndCows.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new GameModel { };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(GameModel model)
        {
            
            if (!ModelState.IsValid || model.PlayerGuess == 0)
            {
                return View(nameof(Index), model);
            }

            var result = _gameService.PlayGame(model, Username);

            return View(nameof(Index), result);
        }
    }
}