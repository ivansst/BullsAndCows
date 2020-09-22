using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BullsAndCows.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string Username => User.Identity.Name;
    }
}