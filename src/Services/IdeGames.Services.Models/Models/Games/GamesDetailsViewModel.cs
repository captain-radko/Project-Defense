using IdeGames.Data.Models;
using IdeGames.Services.Mapping;

namespace IdeGames.Services.Models.Models.Games
{
    public class GamesDetailsViewModel : IMapFrom<Game>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}