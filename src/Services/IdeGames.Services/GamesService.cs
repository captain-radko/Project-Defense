using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeGames.Data;
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
    }
}