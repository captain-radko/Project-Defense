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
            var viewModel = this.Db.Games
                .Select(x =>
                    new GamesViewModel
                    { 
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price
                    });
            var model = new IndexGamesViewModel
            {
                Games = viewModel
            };

            return View(model);
        }

        public IActionResult Info(int id)
        {
            var game = this.gamesService.GetGameById(id);
            return this.View(game);
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