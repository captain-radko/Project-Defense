﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdeGames.Services.Contracts;
using IdeGames.Services.Models.Models.Games;
using IdeGames.Web.Models;
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

            return this.Redirect("/Games/Create");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var game = gamesService.LoadUpdateGame(id);

            return this.View(game);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(UpdateGameInputModel model)
        {
            var game = this.Db.Games.FirstOrDefault(x => x.Id == model.Id);

            var ids = this.Db.Games.Select(x => x.Id);
            if (model.Id > ids.Last())
            {
                return this.RedirectToAction("Index");
            }

            if (game != null)
            {
                game.Id = model.Id;
                game.Name = model.Name;
                game.Description = model.Description;
                game.Price = model.Price;
                this.Db.SaveChanges();
            }

            return this.Redirect("/Games/Edit");
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