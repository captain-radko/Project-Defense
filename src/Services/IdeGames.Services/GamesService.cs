using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeGames.Data;
using IdeGames.Data.Models;
using IdeGames.Services.Contracts;
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
                .Select(x => new GamesDetailsViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description
                }).FirstOrDefault();
            return games;
        }

        public IndexGamesViewModel GetGames()
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

            return model;
        }

        public Game CreateGame(CreateGameInputModel model)
        {
            var game = new Game
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
            return game;
        }

        public UpdateGameInputModel LoadUpdateGame(int id)
        {
            var viewModel = this.Db.Games
                .Select(x => new UpdateGameInputModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                })
                .FirstOrDefault(x => x.Id == id);
            return viewModel;
        }
    }
}