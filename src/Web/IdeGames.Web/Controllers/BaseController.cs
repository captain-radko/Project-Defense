using IdeGames.Data;
using IdeGames.Services.Models.Models.Error;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new IdeGamesContext();
        }

        protected IdeGamesContext Db { get; }

        public IActionResult CustomError(string errorMessage)
        {
            object viewModel = new ErrorViewModel {Error = errorMessage};
            return this.View("CustomError", viewModel);
        }
    }
}