﻿using System;
using System.Linq;
using IdeGames.Data;
using IdeGames.Data.Models;
using IdeGames.Services.Contracts;
using IdeGames.Services.Mapping;
using IdeGames.Services.Models.Models.Games;

namespace IdeGames.Services
{
    public class GamesService : IGamesService
    {
        public GamesService()
        {
            this.Db = new IdeGamesContext();
        }

        protected IdeGamesContext Db { get; }

        public GamesDetailsViewModel GetGameById(int id)
        {
            var games = this.Db.Games.Where(i => i.Id == id)
                .To<GamesDetailsViewModel>().FirstOrDefault();
            return games;
        }

        public IndexGamesViewModel GetGames()
        {
            var viewModel = this.Db.Games
                .To<GamesViewModel>();
            var model = new IndexGamesViewModel
            {
                Games = viewModel
            };
            if (viewModel == null)
            {
                throw new ApplicationException("No game found");
            }
            return model;
        }

        public Game CreateGame(CreateGameInputModel model)
        {
            var game = new Game
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
            return game;
        }

        public UpdateGameInputModel LoadUpdateGame(int id)
        {
            var viewModel = this.Db.Games
                .To<UpdateGameInputModel>()
                .FirstOrDefault(x => x.Id == id);
            return viewModel;
        }
    }
}