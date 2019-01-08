using IdeGames.Data.Models;
using IdeGames.Services.Mapping;

namespace IdeGames.Services.Models.Models.Games
{
    public class UpdateGameInputModel : CreateGameInputModel, IMapFrom<Game>
    {
    }
}
