using System;
using System.Collections.Generic;
using System.Text;
using IdeGames.Data.Common;
using IdeGames.Data.Models;

namespace IdeGames.Services.Models.Models.Games
{
    public class GamesViewModel : BaseModel<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
