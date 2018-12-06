using IdeGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeGames.Services.Models.Models.Games
{
    public class IndexGamesViewModel
    {
        public  IEnumerable<GamesViewModel> Games { get; set; }
    }
}
