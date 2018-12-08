using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.Games;
using Microsoft.AspNetCore.Mvc;

namespace IdeGames.Web.Controllers
{
    public class GamesController : BaseController
    {
        public IActionResult Index()
        {
            var viewModel = this.Db.Games
                .Select(x =>
                    new GamesViewModel
                    { 
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        ImageUrl = x.ImageUrl
                    });
            var model = new IndexGamesViewModel
            {
                Games = viewModel
            };

            return View(model);
        }
    }
}