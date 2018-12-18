using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Models;
using IdeGames.Services.Models.Models.Games;

namespace IdeGames.Services.Contracts
{
    public interface IGamesService
    {
        GamesDetailsViewModel GetGameById(int id);

        IndexGamesViewModel GetGames();

        Game CreateGame(CreateGameInputModel model);

        UpdateGameInputModel LoadUpdateGame(int id);
    }
}
