using System.Linq;
using IdeGames.Services.Contracts;
using IdeGames.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var user = accountService.GetUsers();
            return this.View(user);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(string id)
        {
            var user = this.Db.Users.FirstOrDefault(i => i.Id == id);

            if (user == null)
            {
                return this.CustomError(Constants.UserDoesNotExists);
            }

            this.Db.Remove(user);

            this.Db.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}