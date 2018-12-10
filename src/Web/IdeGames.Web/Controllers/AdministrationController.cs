using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class AdministrationController : BaseController
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}