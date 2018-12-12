using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class GamesController : BaseController
    {
        private readonly IGamesService gamesService;

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var viewModel = gamesService.GetGames();

            return View(viewModel);
        }

        public IActionResult Info(int id)
        {
            var game = this.gamesService.GetGameById(id);
            return this.View(game);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(CreateGameInputModel model)
        {
            var game = gamesService.CreateGame(model);

            this.Db.Add(game);

            this.Db.SaveChanges();

            return this.Redirect("/Administration/AdminIndex");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var game = this.Db.Games.FirstOrDefault(g => g.Id == id);

            this.Db.Remove(game ?? throw new InvalidOperationException());

            this.Db.SaveChanges();

            return this.Redirect("/Administration/AdminIndex");
        }
    }
}