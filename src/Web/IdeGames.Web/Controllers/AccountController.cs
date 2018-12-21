using System;
using System.Linq;
using IdeGames.Services.Contracts;
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

            this.Db.Remove(user ?? throw new InvalidOperationException());

            this.Db.SaveChanges();

            return this.Redirect("/Account/Index");
        }
    }
}