using BullsAndCows.Models;
using BullsAndCows.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BullsAndCows.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserTriesService _userTriesService;

        public HomeController(IUserTriesService userTriesService)
        {
            _userTriesService = userTriesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Scoreboard()
        {
            var userTries = _userTriesService.GetAll();

            var model = new UserTriesModel
            {
                UserTries = userTries
            };


            return View(model);
        }
    }
}
