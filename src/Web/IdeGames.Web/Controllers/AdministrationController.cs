using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class AdministrationController : BaseController
    {
        public IActionResult AdminIndex()
        {
            return this.View();
        }
    }
}
